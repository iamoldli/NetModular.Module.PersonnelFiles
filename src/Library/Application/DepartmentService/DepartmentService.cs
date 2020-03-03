using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Lib.Cache.Abstractions;
using NetModular.Lib.Utils.Core.Extensions;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.PersonnelFiles.Application.DepartmentService.ResultModels;
using NetModular.Module.PersonnelFiles.Application.DepartmentService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Department;
using NetModular.Module.PersonnelFiles.Domain.Department.Models;
using NetModular.Module.PersonnelFiles.Domain.Employee;
using NetModular.Module.PersonnelFiles.Infrastructure;

namespace NetModular.Module.PersonnelFiles.Application.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _repository;
        private readonly IEmployeeRepository _userRepository;
        private readonly ICacheHandler _cacheHandler;

        public DepartmentService(IMapper mapper, IDepartmentRepository repository, IEmployeeRepository userRepository, ICacheHandler cacheHandler)
        {
            _mapper = mapper;
            _repository = repository;
            _userRepository = userRepository;
            _cacheHandler = cacheHandler;
        }

        public async Task<IResultModel> GetTree()
        {
            if (_cacheHandler.TryGetValue(CacheKeys.DepartmentTree, out List<TreeResultModel<Guid, DepartmentTreeResultModel>> list))
                return ResultModel.Success(list);

            var all = await _repository.GetAllAsync();
            list = ResolveTree(all, Guid.Empty);

            await _cacheHandler.SetAsync(CacheKeys.DepartmentTree, list);

            return ResultModel.Success(list);
        }

        private List<TreeResultModel<Guid, DepartmentTreeResultModel>> ResolveTree(IList<DepartmentEntity> all, Guid parentId)
        {
            return all.Where(m => m.ParentId == parentId).OrderBy(m => m.Sort)
                .Select(m => new TreeResultModel<Guid, DepartmentTreeResultModel>
                {
                    Id = m.Id,
                    Label = m.Name,
                    Item = _mapper.Map<DepartmentTreeResultModel>(m),
                    Children = ResolveTree(all, m.Id)
                }).ToList();
        }

        public async Task<IResultModel> Query(DepartmentQueryModel model)
        {
            var result = new QueryResultModel<DepartmentEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(DepartmentAddModel model)
        {
            if (await _repository.ExistsName(model.Name, model.ParentId))
            {
                return ResultModel.Failed("所属部门中已存在名称相同的部门");
            }
            if (model.Code.NotNull() && await _repository.ExistsCode(model.Code))
            {
                return ResultModel.Failed("编码已存在");
            }

            var entity = _mapper.Map<DepartmentEntity>(model);
            entity.FullPath = $"/{entity.Name}";
            //查询父级
            if (model.ParentId.NotEmpty())
            {
                var parent = await _repository.GetAsync(model.ParentId);
                if (parent != null)
                {
                    //设置等级
                    entity.Level = parent.Level++;
                    //设置完整路径
                    entity.FullPath = $"{parent.FullPath}/{entity.Name}";
                }
            }

            var result = await _repository.AddAsync(entity);
            if (result)
            {
                await ClearCache();
                return ResultModel.Success(entity);
            }

            return ResultModel.Failed();
        }

        public async Task<IResultModel> Delete(Guid id)
        {
            if (await _repository.ExistsChildren(id))
            {
                return ResultModel.Failed("当前部门包含子部门，请先删除子部门");
            }

            if (await _userRepository.ExistsBindDept(id))
            {
                return ResultModel.Failed("当前部门包含用户，请先删除用户");
            }

            var result = await _repository.DeleteAsync(id);
            if (result)
            {
                await ClearCache();
            }
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Edit(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            var model = _mapper.Map<DepartmentUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(DepartmentUpdateModel model)
        {
            var entity = await _repository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            _mapper.Map(model, entity);

            if (await _repository.ExistsName(entity.Name, entity.ParentId, entity.Id))
            {
                return ResultModel.Failed("所属部门中已存在名称相同的部门");
            }
            if (model.Code.NotNull() && await _repository.ExistsCode(entity.Code, entity.Id))
            {
                return ResultModel.Failed("编码已存在");
            }

            entity.FullPath = entity.Name;
            //查询父级
            if (model.ParentId.NotEmpty())
            {
                var parent = await _repository.GetAsync(model.ParentId);
                if (parent != null)
                {
                    //设置完整路径
                    entity.FullPath = $"{parent.FullPath}/{entity.Name}";
                }
            }
            var result = await _repository.UpdateAsync(entity);
            if (result)
            {
                await ClearCache();
            }
            return ResultModel.Result(result);
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        /// <returns></returns>
        private Task ClearCache()
        {
            var task1 = _cacheHandler.RemoveAsync(CacheKeys.DepartmentTree);
            var task2 = _cacheHandler.RemoveAsync(CacheKeys.EmployeeTree);

            return Task.WhenAll(task1, task2);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Lib.Cache.Abstractions;
using NetModular.Module.PersonnelFiles.Application.PostService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Employee;
using NetModular.Module.PersonnelFiles.Domain.Post;
using NetModular.Module.PersonnelFiles.Domain.Post.Models;
using NetModular.Module.PersonnelFiles.Infrastructure;

namespace NetModular.Module.PersonnelFiles.Application.PostService
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _repository;
        private readonly IEmployeeRepository _userRepository;
        private readonly ICacheHandler _cacheHandler;

        public PostService(IMapper mapper, IPostRepository repository, IEmployeeRepository userRepository, ICacheHandler cacheHandler)
        {
            _mapper = mapper;
            _repository = repository;
            _userRepository = userRepository;
            _cacheHandler = cacheHandler;
        }

        public async Task<IResultModel> Query(PostQueryModel model)
        {
            var result = new QueryResultModel<PostEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(PostAddModel model)
        {
            if (await _repository.ExistsName(model.Name))
                return ResultModel.Failed("名称已存在");

            var entity = _mapper.Map<PostEntity>(model);

            var result = await _repository.AddAsync(entity);
            if (result)
            {
                await _cacheHandler.RemoveAsync(CacheKeys.POST_SELECT);
            }
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Delete(int id)
        {
            if (!await _repository.ExistsAsync(id))
                return ResultModel.NotExists;

            if (await _userRepository.ExistsBindPost(id))
                return ResultModel.Failed("有用户绑定了该职位，请先删除绑定关系");

            var result = await _repository.DeleteAsync(id);
            if (result)
            {
                await _cacheHandler.RemoveAsync(CacheKeys.POST_SELECT);
            }
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Edit(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            var model = _mapper.Map<PostUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(PostUpdateModel model)
        {
            if (await _repository.ExistsName(model.Name, model.Id))
                return ResultModel.Failed("名称已存在");

            var entity = await _repository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            _mapper.Map(model, entity);

            var result = await _repository.UpdateAsync(entity);
            if (result)
            {
                await _cacheHandler.RemoveAsync(CacheKeys.POST_SELECT);
            }
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Select()
        {
            if (!_cacheHandler.TryGetValue(CacheKeys.POST_SELECT, out List<OptionResultModel> list))
            {
                var all = await _repository.GetAllAsync();
                list = all.Select(m => new OptionResultModel
                {
                    Label = m.Name,
                    Value = m.Id
                }).ToList();

                await _cacheHandler.SetAsync(CacheKeys.POST_SELECT, list);
            }

            return ResultModel.Success(list);
        }
    }
}

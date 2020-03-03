using System.Threading.Tasks;
using AutoMapper;
using NetModular.Lib.Utils.Core.Extensions;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.PersonnelFiles.Application.PositionService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Position;
using NetModular.Module.PersonnelFiles.Domain.Position.Models;
using NetModular.Module.PersonnelFiles.Domain.Post;

namespace NetModular.Module.PersonnelFiles.Application.PositionService
{
    public class PositionService : IPositionService
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _repository;
        private readonly IPostRepository _postRepository;

        public PositionService(IMapper mapper, IPositionRepository repository, IPostRepository postRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _postRepository = postRepository;
        }

        public async Task<IResultModel> Query(PositionQueryModel model)
        {
            var result = new QueryResultModel<PositionEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(PositionAddModel model)
        {
            var entity = _mapper.Map<PositionEntity>(model);
            if (await _repository.ExistsName(entity.Name))
                return ResultModel.Failed("名称已存在");

            if (entity.Code.NotNull() && await _repository.ExistsCode(entity.Code))
                return ResultModel.Failed("名称已存在");

            var result = await _repository.AddAsync(entity);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Delete(int id)
        {
            if (!await _repository.ExistsAsync(id))
            {
                return ResultModel.Failed("数据不存在");
            }

            if (await _postRepository.ExistsPosition(id))
            {
                return ResultModel.Failed("有岗位关联了该职位，请先删除岗位");
            }

            var result = await _repository.DeleteAsync(id);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Edit(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            var model = _mapper.Map<PositionUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(PositionUpdateModel model)
        {
            if (await _repository.ExistsName(model.Name, model.Id))
                return ResultModel.Failed("名称已存在");

            if (model.Code.NotNull() && await _repository.ExistsCode(model.Code, model.Id))
                return ResultModel.Failed("名称已存在");

            var entity = await _repository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            _mapper.Map(model, entity);

            var result = await _repository.UpdateAsync(entity);

            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Get(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity != null)
            {
                return ResultModel.Success(entity);
            }

            return ResultModel.Failed();
        }
    }
}

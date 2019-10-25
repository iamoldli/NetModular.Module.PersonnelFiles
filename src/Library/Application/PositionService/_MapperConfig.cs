using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.PersonnelFiles.Application.PositionService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Position;

namespace NetModular.Module.PersonnelFiles.Application.PositionService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<PositionAddModel, PositionEntity>();
            cfg.CreateMap<PositionEntity, PositionUpdateModel>();
            cfg.CreateMap<PositionUpdateModel, PositionEntity>();
        }
    }
}

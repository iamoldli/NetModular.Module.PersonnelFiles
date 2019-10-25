using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.PersonnelFiles.Application.UserEducationHistoryService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.UserEducationHistory;

namespace NetModular.Module.PersonnelFiles.Application.UserEducationHistoryService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserEducationHistoryAddModel, UserEducationHistoryEntity>();
            cfg.CreateMap<UserEducationHistoryEntity, UserEducationHistoryUpdateModel>();
            cfg.CreateMap<UserEducationHistoryUpdateModel, UserEducationHistoryEntity>();
        }
    }
}

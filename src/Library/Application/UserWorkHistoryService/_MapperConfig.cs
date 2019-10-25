using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.PersonnelFiles.Application.UserWorkHistoryService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.UserWorkHistory;

namespace NetModular.Module.PersonnelFiles.Application.UserWorkHistoryService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserWorkHistoryAddModel, UserWorkHistoryEntity>();
            cfg.CreateMap<UserWorkHistoryEntity, UserWorkHistoryUpdateModel>();
            cfg.CreateMap<UserWorkHistoryUpdateModel, UserWorkHistoryEntity>();
        }
    }
}

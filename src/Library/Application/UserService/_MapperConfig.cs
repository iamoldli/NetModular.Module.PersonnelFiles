using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.PersonnelFiles.Application.UserService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.User;
using NetModular.Module.PersonnelFiles.Domain.UserContact;

namespace NetModular.Module.PersonnelFiles.Application.UserService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserAddModel, UserEntity>();
            cfg.CreateMap<UserEntity, UserUpdateModel>();
            cfg.CreateMap<UserUpdateModel, UserEntity>();

            cfg.CreateMap<UserContactUpdateViewModel, UserContactEntity>();
            cfg.CreateMap<UserContactEntity, UserContactUpdateViewModel>();
        }
    }
}

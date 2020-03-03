using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.PersonnelFiles.Application.PostService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Post;

namespace NetModular.Module.PersonnelFiles.Application.PostService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<PostAddModel, PostEntity>();
            cfg.CreateMap<PostEntity, PostUpdateModel>();
            cfg.CreateMap<PostUpdateModel, PostEntity>();
        }
    }
}

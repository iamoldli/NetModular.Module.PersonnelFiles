using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.PersonnelFiles.Application.CompanyService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Company;

namespace NetModular.Module.PersonnelFiles.Application.CompanyService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CompanyAddModel, CompanyEntity>();
            cfg.CreateMap<CompanyEntity, CompanyUpdateModel>();
            cfg.CreateMap<CompanyUpdateModel, CompanyEntity>();
        }
    }
}

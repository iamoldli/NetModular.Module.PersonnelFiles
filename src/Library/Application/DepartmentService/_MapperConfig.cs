using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.PersonnelFiles.Application.DepartmentService.ResultModels;
using NetModular.Module.PersonnelFiles.Application.DepartmentService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Department;

namespace NetModular.Module.PersonnelFiles.Application.DepartmentService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<DepartmentAddModel, DepartmentEntity>();
            cfg.CreateMap<DepartmentEntity, DepartmentUpdateModel>();
            cfg.CreateMap<DepartmentUpdateModel, DepartmentEntity>();
            cfg.CreateMap<DepartmentEntity, DepartmentTreeResultModel>();
        }
    }
}

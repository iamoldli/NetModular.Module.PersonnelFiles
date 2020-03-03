using AutoMapper;
using NetModular.Lib.Mapper.AutoMapper;
using NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Employee;
using NetModular.Module.PersonnelFiles.Domain.EmployeeContact;
using NetModular.Module.PersonnelFiles.Domain.EmployeeEducation;
using NetModular.Module.PersonnelFiles.Domain.EmployeeFamily;
using NetModular.Module.PersonnelFiles.Domain.EmployeeLeaveInfo;
using NetModular.Module.PersonnelFiles.Domain.EmployeePersonal;
using NetModular.Module.PersonnelFiles.Domain.EmployeeWork;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<EmployeeAddModel, EmployeeEntity>();
            cfg.CreateMap<EmployeeEntity, EmployeeBaseUpdateModel>();
            cfg.CreateMap<EmployeeBaseUpdateModel, EmployeeEntity>();

            //离职信息
            cfg.CreateMap<EmployeeLeaveModel, EmployeeLeaveInfoEntity>();

            //个人信息
            cfg.CreateMap<EmployeePersonalUpdateModel, EmployeePersonalEntity>();
            cfg.CreateMap<EmployeePersonalEntity, EmployeePersonalUpdateModel>();

            //通讯信息
            cfg.CreateMap<EmployeeContactUpdateModel, EmployeeContactEntity>();
            cfg.CreateMap<EmployeeContactEntity, EmployeeContactUpdateModel>();

            //家庭情况
            cfg.CreateMap<EmployeeFamilyAddModel, EmployeeFamilyEntity>();
            cfg.CreateMap<EmployeeFamilyUpdateModel, EmployeeFamilyEntity>();
            cfg.CreateMap<EmployeeFamilyEntity, EmployeeFamilyUpdateModel>();

            //教育背景
            cfg.CreateMap<EmployeeEducationAddModel, EmployeeEducationEntity>();
            cfg.CreateMap<EmployeeEducationUpdateModel, EmployeeEducationEntity>();
            cfg.CreateMap<EmployeeEducationEntity, EmployeeEducationUpdateModel>();

            //工作经历
            cfg.CreateMap<EmployeeWorkAddModel, EmployeeWorkEntity>();
            cfg.CreateMap<EmployeeWorkUpdateModel, EmployeeWorkEntity>();
            cfg.CreateMap<EmployeeWorkEntity, EmployeeWorkUpdateModel>();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NetModular.Lib.Auth.Abstractions;
using NetModular.Lib.Cache.Abstractions;
using NetModular.Lib.Utils.Core.Models;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Admin.Application.AccountService;
using NetModular.Module.Admin.Application.AccountService.ViewModels;
using NetModular.Module.Admin.Domain.Account;
using NetModular.Module.Admin.Domain.AccountRole;
using NetModular.Module.Admin.Infrastructure.Repositories;
using NetModular.Module.PersonnelFiles.Application.EmployeeService.ResultModels;
using NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Department;
using NetModular.Module.PersonnelFiles.Domain.Employee;
using NetModular.Module.PersonnelFiles.Domain.Employee.Models;
using NetModular.Module.PersonnelFiles.Domain.EmployeeContact;
using NetModular.Module.PersonnelFiles.Domain.EmployeeEducation;
using NetModular.Module.PersonnelFiles.Domain.EmployeeFamily;
using NetModular.Module.PersonnelFiles.Domain.EmployeeLatestSelect;
using NetModular.Module.PersonnelFiles.Domain.EmployeeLatestSelect.Models;
using NetModular.Module.PersonnelFiles.Domain.EmployeeLeaveInfo;
using NetModular.Module.PersonnelFiles.Domain.EmployeePersonal;
using NetModular.Module.PersonnelFiles.Domain.EmployeeWork;
using NetModular.Module.PersonnelFiles.Infrastructure;
using NetModular.Module.PersonnelFiles.Infrastructure.Repositories;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repository;
        private readonly IAccountService _accountService;
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeContactRepository _contactRepository;
        private readonly IEmployeeLeaveInfoRepository _leaveInfoRepository;
        private readonly IEmployeePersonalRepository _personalRepository;
        private readonly IEmployeeFamilyRepository _familyRepository;
        private readonly IEmployeeEducationRepository _educationRepository;
        private readonly IEmployeeWorkRepository _workRepository;
        private readonly IEmployeeLatestSelectRepository _latestSelectRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly AdminDbContext _adminDbContext;
        private readonly PersonnelFilesDbContext _dbContext;
        private readonly ICacheHandler _cacheHandler;
        private readonly PersonnelFilesOptions _options;

        public EmployeeService(IMapper mapper, IEmployeeRepository repository, IAccountService accountService, IAccountRepository accountRepository, IEmployeeContactRepository contactRepository, AdminDbContext adminDbContext, PersonnelFilesDbContext dbContext, IEmployeeLeaveInfoRepository leaveInfoRepository, IEmployeePersonalRepository personalRepository, IEmployeeFamilyRepository familyRepository, IEmployeeEducationRepository educationRepository, IEmployeeWorkRepository workRepository, IEmployeeLatestSelectRepository latestSelectRepository, ICacheHandler cacheHandler, IDepartmentRepository departmentRepository, IAccountRoleRepository accountRoleRepository, PersonnelFilesOptions options)
        {
            _mapper = mapper;
            _repository = repository;
            _accountService = accountService;
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
            _adminDbContext = adminDbContext;
            _dbContext = dbContext;
            _leaveInfoRepository = leaveInfoRepository;
            _personalRepository = personalRepository;
            _familyRepository = familyRepository;
            _educationRepository = educationRepository;
            _workRepository = workRepository;
            _latestSelectRepository = latestSelectRepository;
            _cacheHandler = cacheHandler;
            _departmentRepository = departmentRepository;
            _accountRoleRepository = accountRoleRepository;
            _options = options;
        }

        #region ==基本信息==

        public async Task<IResultModel> Query(EmployeeQueryModel model)
        {
            if (model.JobNo != null)
            {
                model.JobNo = model.JobNo - 1000000;
            }

            var result = new QueryResultModel<EmployeeEntity>
            {
                Rows = await _repository.Query(model),
                Total = model.TotalCount
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> Add(EmployeeAddModel model)
        {
            if (model.Password.NotNull() && !model.Password.Equals(model.ConfirmPassword))
                return ResultModel.Failed("两次输入的密码不同");

            var entity = _mapper.Map<EmployeeEntity>(model);
            entity.JoinDate = entity.JoinDate.Date;

            var account = new AccountAddModel
            {
                Type = AccountType.User,//使用User账户类型
                UserName = model.UserName,
                Name = model.Name,
                Password = model.Password,
                IsLock = true,
                Roles = model.Roles
            };

            var result = await _accountService.Add(account);
            if (result.Successful)
            {
                entity.AccountId = result.Data;
                if (await _repository.AddAsync(entity))
                {
                    await _cacheHandler.RemoveAsync(CacheKeys.EMPLOYEE_TREE);
                    return ResultModel.Success();
                }
            }

            return result;
        }

        public async Task<IResultModel> Delete(int id)
        {
            var employee = await _repository.GetAsync(id);
            if (employee == null)
                return ResultModel.Failed("员工信息不存在");

            var account = await _accountRepository.GetAsync(employee.AccountId);
            if (account == null)
                return ResultModel.Failed("账户信息不存在");

            using var uow = _dbContext.NewUnitOfWork();
            using var adminUow = _adminDbContext.NewUnitOfWork();

            var result = await _repository.SoftDeleteAsync(id, uow);
            if (result)
            {
                result = await _accountRepository.SoftDeleteAsync(account.Id, adminUow);
                if (result)
                {
                    uow.Commit();
                    adminUow.Commit();

                    //清除缓存
                    await _cacheHandler.RemoveAsync(CacheKeys.EMPLOYEE_TREE);
                    await _cacheHandler.RemoveAsync($"{CacheKeys.EMPLOYEE_BASE_INFO}:{employee.Id}");

                    return ResultModel.Success();
                }
            }
            return ResultModel.Failed();
        }

        public async Task<IResultModel> Edit(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            var model = _mapper.Map<EmployeeBaseUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> Update(EmployeeBaseUpdateModel model)
        {
            var entity = await _repository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            _mapper.Map(model, entity);
            entity.JoinDate = entity.JoinDate.Date;

            var result = await _repository.UpdateAsync(entity);
            if (result)
            {
                var account = await _accountRepository.GetAsync(entity.AccountId);
                if (account != null)
                {
                    var syncModel = new AccountSyncModel
                    {
                        Id = account.Id,
                        Name = entity.Name,
                        Email = account.Email,
                        Phone = account.Phone,
                        Roles = null,
                        UserName = account.UserName
                    };

                    await _accountService.Sync(syncModel);
                }

                //清除缓存
                await _cacheHandler.RemoveAsync(CacheKeys.EMPLOYEE_TREE);
                await _cacheHandler.RemoveAsync($"{CacheKeys.EMPLOYEE_BASE_INFO}:{entity.Id}");
            }
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> Leave(EmployeeLeaveModel model)
        {
            var entity = await _repository.GetAsync(model.EmployeeId);
            if (entity == null)
                return ResultModel.NotExists;
            if (entity.Status == EmployeeStatus.Leave)
                return ResultModel.Failed("该人员已办理过离职");

            using var uow = _dbContext.NewUnitOfWork();
            var result = await _repository.UpdateLeaveStatus(model.EmployeeId, uow);
            if (result)
            {
                var leaveInfo = _mapper.Map<EmployeeLeaveInfoEntity>(model);
                leaveInfo.EmployeeId = model.EmployeeId;
                result = await _leaveInfoRepository.AddAsync(leaveInfo, uow);
                if (result)
                {
                    uow.Commit();

                    //清除缓存
                    await _cacheHandler.RemoveAsync(CacheKeys.EMPLOYEE_TREE);
                    await _cacheHandler.RemoveAsync($"{CacheKeys.EMPLOYEE_BASE_INFO}:{entity.Id}");

                    return ResultModel.Success();
                }
            }
            return ResultModel.Failed();
        }

        public async Task<IResultModel> GetLeaveInfo(int id)
        {
            var info = await _leaveInfoRepository.GetByEmployeeId(id);
            return ResultModel.Success(info);
        }

        #endregion

        #region ==个人信息==

        public async Task<IResultModel> EditPersonal(int id)
        {
            var user = await _repository.GetAsync(id);
            if (user == null)
                return ResultModel.NotExists;

            var model = new EmployeePersonalUpdateModel
            {
                EmployeeId = id
            };
            var entity = await _personalRepository.GetByEmployee(id);
            if (entity != null)
            {
                _mapper.Map(entity, model);
            }

            return ResultModel.Success(model);
        }

        public async Task<IResultModel> UpdatePersonal(EmployeePersonalUpdateModel model)
        {
            var entity = await _personalRepository.GetByEmployee(model.EmployeeId) ?? new EmployeePersonalEntity();

            _mapper.Map(model, entity);

            bool result;
            if (entity.Id > 0)
            {
                result = await _personalRepository.UpdateAsync(entity);
            }
            else
            {
                result = await _personalRepository.AddAsync(entity);
            }

            return ResultModel.Result(result);
        }

        #endregion

        #region ==家庭情况==

        public async Task<IResultModel> FamilyQuery(int employeeId)
        {
            var list = await _familyRepository.Query(employeeId);
            var result = new QueryResultModel<EmployeeFamilyEntity>
            {
                Rows = list,
                Total = list.Count
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> FamilyAdd(EmployeeFamilyAddModel model)
        {
            var entity = _mapper.Map<EmployeeFamilyEntity>(model);
            var result = await _familyRepository.AddAsync(entity);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> FamilyDelete(int id)
        {
            var result = await _familyRepository.DeleteAsync(id);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> FamilyEdit(int id)
        {
            var entity = await _familyRepository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            var model = _mapper.Map<EmployeeFamilyUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> FamilyUpdate(EmployeeFamilyUpdateModel model)
        {
            var entity = await _familyRepository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            model.EmployeeId = entity.EmployeeId;//防止人员编号被修改
            _mapper.Map(model, entity);

            var result = await _familyRepository.UpdateAsync(entity);
            return ResultModel.Result(result);
        }

        #endregion

        #region ==通讯信息=

        public async Task<IResultModel> EditContact(int id)
        {
            var user = await _repository.GetAsync(id);
            if (user == null)
                return ResultModel.NotExists;

            var model = new EmployeeContactUpdateModel
            {
                EmployeeId = id,
                Area = new AreaSelectModel()
            };
            var entity = await _contactRepository.GetByEmployee(id);
            if (entity != null)
            {
                _mapper.Map(entity, model);

                model.Area.Set(entity.ProvinceCode, entity.CityCode, entity.AreaCode, entity.TownCode);
            }

            return ResultModel.Success(model);
        }

        public async Task<IResultModel> UpdateContact(EmployeeContactUpdateModel model)
        {
            var employee = await _repository.GetAsync(model.EmployeeId);
            if (employee == null)
                return ResultModel.NotExists;

            var entity = await _contactRepository.GetByEmployee(model.EmployeeId) ?? new EmployeeContactEntity();

            _mapper.Map(model, entity);

            ClearContactAreaInfo(entity);

            SetContactAreaInfo(entity, model.Area);

            bool result;
            if (entity.Id > 0)
            {
                result = await _contactRepository.UpdateAsync(entity);
            }
            else
            {
                result = await _contactRepository.AddAsync(entity);
            }

            if (result)
            {
                var account = await _accountRepository.GetAsync(employee.AccountId);
                if (account != null)
                {
                    var syncModel = new AccountSyncModel
                    {
                        Id = account.Id,
                        Name = account.Name,
                        Email = model.Email ?? string.Empty,
                        Phone = model.Phone ?? string.Empty,
                        Roles = null,
                        UserName = account.UserName
                    };

                    await _accountService.Sync(syncModel);
                }

                return ResultModel.Success();
            }

            return ResultModel.Failed();
        }

        public async Task<IResultModel> ContactDetails(int id)
        {
            var user = await _repository.GetAsync(id);
            if (user == null)
                return ResultModel.NotExists;

            var entity = await _contactRepository.GetByEmployee(id);
            return ResultModel.Success(entity ?? new EmployeeContactEntity());
        }

        /// <summary>
        /// 清除联系方式的区域信息
        /// </summary>
        /// <param name="entity"></param>
        private void ClearContactAreaInfo(EmployeeContactEntity entity)
        {
            entity.ProvinceCode = "";
            entity.ProvinceName = "";
            entity.CityCode = "";
            entity.CityName = "";
            entity.AreaCode = "";
            entity.AreaName = "";
            entity.TownCode = "";
            entity.TownName = "";
        }

        /// <summary>
        /// 设置联系方式的区域信息
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="areaInfo"></param>
        private void SetContactAreaInfo(EmployeeContactEntity entity, AreaSelectModel areaInfo)
        {
            if (areaInfo.Province == null)
                return;

            entity.ProvinceCode = areaInfo.Province.Code;
            entity.ProvinceName = areaInfo.Province.Name;

            if (areaInfo.City == null)
                return;

            entity.CityCode = areaInfo.City.Code;
            entity.CityName = areaInfo.City.Name;

            if (areaInfo.Area == null)
                return;

            entity.AreaCode = areaInfo.Area.Code;
            entity.AreaName = areaInfo.Area.Name;

            if (areaInfo.Town == null)
                return;

            entity.TownCode = areaInfo.Town.Code;
            entity.TownName = areaInfo.Town.Name;
        }

        #endregion

        #region ==教育背景==

        public async Task<IResultModel> EducationQuery(int employeeId)
        {
            var list = await _educationRepository.Query(employeeId);
            var result = new QueryResultModel<EmployeeEducationEntity>
            {
                Rows = list,
                Total = list.Count
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> EducationAdd(EmployeeEducationAddModel model)
        {
            var entity = _mapper.Map<EmployeeEducationEntity>(model);
            var result = await _educationRepository.AddAsync(entity);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> EducationDelete(int id)
        {
            var result = await _educationRepository.DeleteAsync(id);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> EducationEdit(int id)
        {
            var entity = await _educationRepository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            var model = _mapper.Map<EmployeeEducationUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> EducationUpdate(EmployeeEducationUpdateModel model)
        {
            var entity = await _educationRepository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            model.EmployeeId = entity.EmployeeId;//防止人员编号被修改
            _mapper.Map(model, entity);

            var result = await _educationRepository.UpdateAsync(entity);
            return ResultModel.Result(result);
        }

        #endregion

        #region ==工作经历==

        public async Task<IResultModel> WorkQuery(int employeeId)
        {
            var list = await _workRepository.Query(employeeId);
            var result = new QueryResultModel<EmployeeWorkEntity>
            {
                Rows = list,
                Total = list.Count
            };
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> WorkAdd(EmployeeWorkAddModel model)
        {
            var entity = _mapper.Map<EmployeeWorkEntity>(model);
            var result = await _workRepository.AddAsync(entity);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> WorkDelete(int id)
        {
            var result = await _workRepository.DeleteAsync(id);
            return ResultModel.Result(result);
        }

        public async Task<IResultModel> WorkEdit(int id)
        {
            var entity = await _workRepository.GetAsync(id);
            if (entity == null)
                return ResultModel.NotExists;

            var model = _mapper.Map<EmployeeWorkUpdateModel>(entity);
            return ResultModel.Success(model);
        }

        public async Task<IResultModel> WorkUpdate(EmployeeWorkUpdateModel model)
        {
            var entity = await _workRepository.GetAsync(model.Id);
            if (entity == null)
                return ResultModel.NotExists;

            model.EmployeeId = entity.EmployeeId;//防止人员编号被修改
            _mapper.Map(model, entity);

            var result = await _workRepository.UpdateAsync(entity);
            return ResultModel.Result(result);
        }

        #endregion

        #region ==账户更新==

        /// <summary>
        /// 账户编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IResultModel> EditAccount(int id)
        {
            var employee = await _repository.GetAsync(id);
            if (employee == null)
                return ResultModel.NotExists;

            var accountTask = _accountRepository.GetAsync(employee.AccountId);
            var rolesTask = _accountRoleRepository.QueryRole(employee.AccountId);

            var account = await accountTask;
            var roles = await rolesTask;

            var model = new EmployeeAccountUpdateModel
            {
                Id = id,
                UserName = account.UserName,
                Roles = roles.Select(m => m.Id).ToList()
            };

            return ResultModel.Success(model);
        }

        /// <summary>
        /// 账户更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IResultModel> UpdateAccount(EmployeeAccountUpdateModel model)
        {
            var employee = await _repository.GetAsync(model.Id);
            if (employee == null)
                return ResultModel.NotExists;

            if (await _accountRepository.ExistsUserName(model.UserName, employee.AccountId, AccountType.User))
                return ResultModel.Failed("用户名已存在");

            var account = await _accountRepository.GetAsync(employee.AccountId);
            if (account != null)
            {
                var syncModel = new AccountSyncModel
                {
                    Id = account.Id,
                    Name = account.Name,
                    Email = account.Email,
                    Phone = account.Phone,
                    Roles = model.Roles,
                    UserName = model.UserName,
                    NewPassword = model.Password
                };

                var result = await _accountService.Sync(syncModel);
                return ResultModel.Result(result.Successful);
            }

            return ResultModel.Failed();
        }

        #endregion

        #region ==人员选择==

        public async Task<IResultModel> QueryWithSameDepartment(Guid accountId, EmployeeQueryModel model)
        {
            var result = new QueryResultModel<EmployeeEntity>();
            var employee = await _repository.GetByAccountId(accountId);
            if (employee == null || employee.DepartmentId.IsEmpty())
                return ResultModel.Success(result);

            model.DepartmentId = employee.DepartmentId;

            result.Rows = await _repository.Query(model);
            result.Rows.Remove(result.Rows.FirstOrDefault(m => m.Id == employee.Id));

            result.Total = model.TotalCount;

            return ResultModel.Success(result);
        }

        public async Task<IResultModel> QueryLatestSelect(Guid accountId, EmployeeLatestSelectQueryModel model)
        {
            var result = new QueryResultModel<EmployeeEntity>();
            var employee = await _repository.GetByAccountId(accountId);
            if (employee == null)
                return ResultModel.Success(result);

            result.Rows = await _latestSelectRepository.Query(employee.Id, model);
            result.Total = model.TotalCount;
            return ResultModel.Success(result);
        }

        public async Task<IResultModel> SaveLatestSelect(Guid accountId, List<int> ids)
        {
            var employee = await _repository.GetByAccountId(accountId);
            if (employee == null)
                return ResultModel.Success();

            if (ids != null && ids.Any())
            {
                var uow = _dbContext.NewUnitOfWork();
                foreach (var relationId in ids)
                {
                    var entity = await _latestSelectRepository.Get(employee.Id, relationId, uow);
                    if (entity == null)
                    {
                        entity = new EmployeeLatestSelectEntity
                        {
                            EmployeeId = employee.Id,
                            RelationId = relationId,
                            Timestamp = DateTime.Now.ToTimestamp()
                        };

                        await _latestSelectRepository.AddAsync(entity, uow);
                    }
                    else
                    {
                        entity.Timestamp = DateTime.Now.ToTimestamp();
                        await _latestSelectRepository.UpdateAsync(entity, uow);
                    }
                }

                uow.Commit();
            }

            return ResultModel.Success();
        }

        public async Task<IResultModel> GetTree()
        {
            if (_cacheHandler.TryGetValue(CacheKeys.EMPLOYEE_TREE, out TreeResultModel<int, EmployeeTreeResultModel> root))
                return ResultModel.Success(root);

            var allDepart = await _departmentRepository.GetAllAsync();

            root = new TreeResultModel<int, EmployeeTreeResultModel>
            {
                Label = _options.CompanyName,
                Item = new EmployeeTreeResultModel
                {
                    SourceId = "",
                    Name = _options.CompanyName
                }
            };

            root.Children = ResolveTree(allDepart, Guid.Empty, root);

            root.Id = 0;

            if (root.Children.Any())
            {
                await _cacheHandler.SetAsync(CacheKeys.EMPLOYEE_TREE, root);
            }

            return ResultModel.Success(root);
        }

        private List<TreeResultModel<int, EmployeeTreeResultModel>> ResolveTree(IList<DepartmentEntity> all, Guid parentId, TreeResultModel<int, EmployeeTreeResultModel> root)
        {
            return all.Where(m => m.ParentId == parentId).OrderBy(m => m.Sort)
                .Select(m =>
                {
                    var node = new TreeResultModel<int, EmployeeTreeResultModel>
                    {
                        Id = ++root.Id,
                        Label = m.Name,
                        Item = new EmployeeTreeResultModel
                        {
                            SourceId = m.Id.ToString(),
                            Name = m.Name
                        },
                        Children = new List<TreeResultModel<int, EmployeeTreeResultModel>>()
                    };

                    node.Children.AddRange(ResolveTree(all, m.Id, root));

                    var employeeList = _repository.QueryByDepartment(m.Id).Result;
                    if (employeeList.Any())
                    {
                        foreach (var employeeEntity in employeeList)
                        {
                            //排除已离职人员
                            if (employeeEntity.Status == EmployeeStatus.Leave)
                                continue;

                            node.Children.Add(new TreeResultModel<EmployeeTreeResultModel>
                            {
                                Id = ++root.Id,
                                Label = employeeEntity.Name,
                                Item = new EmployeeTreeResultModel
                                {
                                    Type = 1,
                                    SourceId = employeeEntity.Id.ToString(),
                                    Name = employeeEntity.Name,
                                    PostName = employeeEntity.PostName,
                                    Sex = employeeEntity.Sex,
                                    DepartmentPath = employeeEntity.DepartmentPath
                                }
                            });
                        }
                    }

                    return node;
                }).ToList();
        }

        public async Task<IResultModel> GetBaseInfoList(List<int> ids)
        {
            var list = new List<EmployeeEntity>();
            if (ids != null && ids.Any())
            {
                foreach (var id in ids)
                {
                    var key = $"{CacheKeys.EMPLOYEE_BASE_INFO}:{id}";
                    if (!_cacheHandler.TryGetValue(key, out EmployeeEntity employee))
                    {
                        employee = await _repository.GetWidthExtend(id);
                        if (employee != null)
                        {
                            await _cacheHandler.SetAsync(key, employee);
                        }
                    }

                    if (employee != null)
                    {
                        list.Add(employee);
                    }
                }
            }

            return ResultModel.Success(list);
        }

        #endregion
    }
}

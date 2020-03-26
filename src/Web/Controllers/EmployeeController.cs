using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Abstractions;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Module.PersonnelFiles.Application.EmployeeService;
using NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Employee.Models;
using NetModular.Module.PersonnelFiles.Domain.EmployeeLatestSelect.Models;

namespace NetModular.Module.PersonnelFiles.Web.Controllers
{
    [Description("员工管理")]
    public class EmployeeController : ModuleController
    {
        private readonly IEmployeeService _service;
        private readonly ILoginInfo _loginInfo;

        public EmployeeController(IEmployeeService service, ILoginInfo loginInfo)
        {
            _service = service;
            _loginInfo = loginInfo;
        }

        #region ==基本信息==

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]EmployeeQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public async Task<IResultModel> Add(EmployeeAddModel model)
        {
            return await _service.Add(model);
        }

        [HttpDelete]
        [Description("删除")]
        public Task<IResultModel> Delete([BindRequired]int id)
        {
            return _service.Delete(id);
        }

        [HttpGet]
        [Description("编辑")]
        public Task<IResultModel> Edit([BindRequired]int id)
        {
            return _service.Edit(id);
        }

        [HttpPost]
        [Description("修改")]
        public Task<IResultModel> Update(EmployeeBaseUpdateModel model)
        {
            return _service.Update(model);
        }

        [HttpPost]
        [Description("离职")]
        public Task<IResultModel> Leave(EmployeeLeaveModel model)
        {
            return _service.Leave(model);
        }

        [HttpGet]
        [Description("获取离职信息")]
        public Task<IResultModel> LeaveInfo([BindRequired]int id)
        {
            return _service.GetLeaveInfo(id);
        }

        #endregion

        #region ==个人信息==

        [HttpGet]
        [Description("编辑个人信息")]
        public Task<IResultModel> EditPersonal([BindRequired]int id)
        {
            return _service.EditPersonal(id);
        }

        [HttpPost]
        [Description("修改个人信息")]
        public Task<IResultModel> UpdatePersonal(EmployeePersonalUpdateModel model)
        {
            return _service.UpdatePersonal(model);
        }

        #endregion

        #region ==家庭情况==

        [HttpGet]
        [Description("查询家庭情况信息列表")]
        public Task<IResultModel> FamilyQuery([BindRequired]int employeeId)
        {
            return _service.FamilyQuery(employeeId);
        }

        [HttpPost]
        [Description("添加家庭情况")]
        public Task<IResultModel> FamilyAdd(EmployeeFamilyAddModel model)
        {
            return _service.FamilyAdd(model);
        }

        [HttpDelete]
        [Description("删除家庭情况")]
        public Task<IResultModel> FamilyDelete([BindRequired]int id)
        {
            return _service.FamilyDelete(id);
        }

        [HttpGet]
        [Description("编辑家庭情况")]
        public Task<IResultModel> FamilyEdit([BindRequired]int id)
        {
            return _service.FamilyEdit(id);
        }

        [HttpPost]
        [Description("修改家庭情况")]
        public Task<IResultModel> FamilyUpdate(EmployeeFamilyUpdateModel model)
        {
            return _service.FamilyUpdate(model);
        }

        #endregion

        #region ==通讯信息==

        [HttpGet]
        [Description("编辑通讯信息")]
        public Task<IResultModel> EditContact([BindRequired]int id)
        {
            return _service.EditContact(id);
        }

        [HttpPost]
        [Description("修改联系信息")]
        public Task<IResultModel> UpdateContact(EmployeeContactUpdateModel model)
        {
            return _service.UpdateContact(model);
        }

        [HttpGet]
        [Description("联系信息详情")]
        public Task<IResultModel> ContactDetails([BindRequired]int id)
        {
            return _service.ContactDetails(id);
        }

        #endregion

        #region ==教育背景==

        [HttpGet]
        [Description("查询教育背景信息列表")]
        public Task<IResultModel> EducationQuery([BindRequired]int employeeId)
        {
            return _service.EducationQuery(employeeId);
        }

        [HttpPost]
        [Description("添加教育背景")]
        public Task<IResultModel> EducationAdd(EmployeeEducationAddModel model)
        {
            return _service.EducationAdd(model);
        }

        [HttpDelete]
        [Description("删除教育背景")]
        public Task<IResultModel> EducationDelete([BindRequired]int id)
        {
            return _service.EducationDelete(id);
        }

        [HttpGet]
        [Description("编辑教育背景")]
        public Task<IResultModel> EducationEdit([BindRequired]int id)
        {
            return _service.EducationEdit(id);
        }

        [HttpPost]
        [Description("修改教育背景")]
        public Task<IResultModel> EducationUpdate(EmployeeEducationUpdateModel model)
        {
            return _service.EducationUpdate(model);
        }

        #endregion

        #region ==工作经历==

        [HttpGet]
        [Description("查询工作经历信息列表")]
        public Task<IResultModel> WorkQuery([BindRequired]int employeeId)
        {
            return _service.WorkQuery(employeeId);
        }

        [HttpPost]
        [Description("添加工作经历")]
        public Task<IResultModel> WorkAdd(EmployeeWorkAddModel model)
        {
            return _service.WorkAdd(model);
        }

        [HttpDelete]
        [Description("删除工作经历")]
        public Task<IResultModel> WorkDelete([BindRequired]int id)
        {
            return _service.WorkDelete(id);
        }

        [HttpGet]
        [Description("编辑工作经历")]
        public Task<IResultModel> WorkEdit([BindRequired]int id)
        {
            return _service.WorkEdit(id);
        }

        [HttpPost]
        [Description("修改工作经历")]
        public Task<IResultModel> WorkUpdate(EmployeeWorkUpdateModel model)
        {
            return _service.WorkUpdate(model);
        }

        #endregion

        #region ==账户更新==

        [HttpGet]
        [Description("账户编辑")]
        public Task<IResultModel> EditAccount([BindRequired]int id)
        {
            return _service.EditAccount(id);
        }

        [HttpPost]
        [Description("账户更新")]
        public Task<IResultModel> UpdateAccount(EmployeeAccountUpdateModel model)
        {
            return _service.UpdateAccount(model);
        }

        #endregion

        #region ==人员选择==

        [HttpGet]
        [Common]
        [Description("查询同一部门下的人员信息")]
        public Task<IResultModel> QueryWithSameDepartment([FromQuery]EmployeeQueryModel model)
        {
            return _service.QueryWithSameDepartment(_loginInfo.AccountId, model);
        }

        [HttpGet]
        [Common]
        [Description("查询最近选择人员列表")]
        public Task<IResultModel> QueryLatestSelect([FromQuery]EmployeeLatestSelectQueryModel model)
        {
            return _service.QueryLatestSelect(_loginInfo.AccountId, model);
        }

        [HttpPost]
        [Common]
        [Description("保存最近人员选择记录")]
        public Task<IResultModel> SaveLatestSelect([FromBody]List<int> ids)
        {
            return _service.SaveLatestSelect(_loginInfo.AccountId, ids);
        }

        [HttpGet]
        [Common]
        [Description("查询人员树")]
        public Task<IResultModel> Tree()
        {
            return _service.GetTree();
        }

        [HttpGet]
        [Common]
        [Description("批量查询人员基本信息")]
        public Task<IResultModel> BaseInfoList([FromQuery]List<int> ids)
        {
            return _service.GetBaseInfoList(ids);
        }

        #endregion
    }
}

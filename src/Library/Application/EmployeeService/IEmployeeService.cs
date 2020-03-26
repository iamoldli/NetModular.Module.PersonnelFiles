using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Employee.Models;
using NetModular.Module.PersonnelFiles.Domain.EmployeeLatestSelect.Models;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService
{
    /// <summary>
    /// 用户信息服务
    /// </summary>
    public interface IEmployeeService
    {
        #region ==基本信息==

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Query(EmployeeQueryModel model);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Add(EmployeeAddModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<IResultModel> Delete(int id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> Edit(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Update(EmployeeBaseUpdateModel model);

        /// <summary>
        /// 离职
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Leave(EmployeeLeaveModel model);

        /// <summary>
        /// 获取指定用户的
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> GetLeaveInfo(int id);

        #endregion

        #region ==个人信息==

        /// <summary>
        /// 编辑联系方式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> EditPersonal(int id);

        /// <summary>
        /// 更新联系方式
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> UpdatePersonal(EmployeePersonalUpdateModel model);

        #endregion

        #region ==家庭情况==

        /// <summary>
        /// 查询家庭情况信息
        /// </summary>
        /// <param name="employeeId">人员编号</param>
        /// <returns></returns>
        Task<IResultModel> FamilyQuery(int employeeId);

        /// <summary>
        /// 添加家庭情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> FamilyAdd(EmployeeFamilyAddModel model);

        /// <summary>
        /// 删除家庭情况
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<IResultModel> FamilyDelete(int id);

        /// <summary>
        /// 编辑家庭情况
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> FamilyEdit(int id);

        /// <summary>
        /// 修改家庭情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> FamilyUpdate(EmployeeFamilyUpdateModel model);

        #endregion

        #region ==联系方式==

        /// <summary>
        /// 编辑联系方式
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> EditContact(int id);

        /// <summary>
        /// 更新联系方式
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> UpdateContact(EmployeeContactUpdateModel model);

        /// <summary>
        /// 联系方式详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> ContactDetails(int id);

        #endregion

        #region ==教育背景==

        /// <summary>
        /// 查询教育背景信息
        /// </summary>
        /// <param name="employeeId">人员编号</param>
        /// <returns></returns>
        Task<IResultModel> EducationQuery(int employeeId);

        /// <summary>
        /// 添加教育背景
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> EducationAdd(EmployeeEducationAddModel model);

        /// <summary>
        /// 删除教育背景
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<IResultModel> EducationDelete(int id);

        /// <summary>
        /// 编辑教育背景
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> EducationEdit(int id);

        /// <summary>
        /// 修改教育背景
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> EducationUpdate(EmployeeEducationUpdateModel model);

        #endregion

        #region ==工作经历==

        /// <summary>
        /// 查询工作经历信息
        /// </summary>
        /// <param name="employeeId">人员编号</param>
        /// <returns></returns>
        Task<IResultModel> WorkQuery(int employeeId);

        /// <summary>
        /// 添加工作经历
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> WorkAdd(EmployeeWorkAddModel model);

        /// <summary>
        /// 删除工作经历
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<IResultModel> WorkDelete(int id);

        /// <summary>
        /// 编辑工作经历
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> WorkEdit(int id);

        /// <summary>
        /// 修改工作经历
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> WorkUpdate(EmployeeWorkUpdateModel model);

        #endregion

        #region ==账户更新==

        /// <summary>
        /// 账户编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> EditAccount(int id);

        /// <summary>
        /// 账户更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> UpdateAccount(EmployeeAccountUpdateModel model);

        #endregion

        #region ==人员选择==

        /// <summary>
        /// 查询同一部门下的人员列表
        /// </summary>
        /// <param name="accountId">账户编号</param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> QueryWithSameDepartment(Guid accountId, EmployeeQueryModel model);

        /// <summary>
        /// 查询最近的选择列表
        /// </summary>
        /// <param name="accountId">账户编号</param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> QueryLatestSelect(Guid accountId, EmployeeLatestSelectQueryModel model);

        /// <summary>
        /// 保存最近的人员选择
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IResultModel> SaveLatestSelect(Guid accountId, List<int> ids);

        /// <summary>
        /// 人员树
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> GetTree();

        /// <summary>
        /// 批量查询人员基本信息(缓存优先)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        Task<IResultModel> GetBaseInfoList(List<int> ids);

        #endregion
    }
}

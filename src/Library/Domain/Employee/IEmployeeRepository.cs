using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.PersonnelFiles.Domain.Employee.Models;

namespace NetModular.Module.PersonnelFiles.Domain.Employee
{
    /// <summary>
    /// 人员信息仓储
    /// </summary>
    public interface IEmployeeRepository : IRepository<EmployeeEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<EmployeeEntity>> Query(EmployeeQueryModel model);

        /// <summary>
        /// 判断是否有人员绑定了指定部门
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        Task<bool> ExistsBindDept(Guid departmentId);

        /// <summary>
        /// 判断是否有人员绑定了指定岗位
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<bool> ExistsBindPost(int postId);

        /// <summary>
        /// 修改离职状态
        /// </summary>
        /// <param name="id">人员编号</param>
        /// <param name="uow"></param>
        /// <returns></returns>
        Task<bool> UpdateLeaveStatus(int id, IUnitOfWork uow);

        /// <summary>
        /// 根据账户编号查询人员信息
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        Task<EmployeeEntity> GetByAccountId(Guid accountId);

        /// <summary>
        /// 查询指定部门下的所有人员列表
        /// </summary>
        /// <param name="departmentId">部门编号</param>
        /// <returns></returns>
        Task<IList<EmployeeEntity>> QueryByDepartment(Guid departmentId);

        /// <summary>
        /// 查询包含扩展属性的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EmployeeEntity> GetWidthExtend(int id);
    }
}

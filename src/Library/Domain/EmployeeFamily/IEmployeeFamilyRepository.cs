using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeFamily
{
    /// <summary>
    /// 人员家庭概况
    /// </summary>
    public interface IEmployeeFamilyRepository : IRepository<EmployeeFamilyEntity>
    {
        /// <summary>
        /// 查询指定人员的家庭概况信息列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<IList<EmployeeFamilyEntity>> Query(int employeeId);
    }
}

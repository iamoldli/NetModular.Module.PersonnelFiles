using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeWork
{
    /// <summary>
    /// 用户工作经历仓储
    /// </summary>
    public interface IEmployeeWorkRepository : IRepository<EmployeeWorkEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<IList<EmployeeWorkEntity>> Query(int employeeId);
    }
}

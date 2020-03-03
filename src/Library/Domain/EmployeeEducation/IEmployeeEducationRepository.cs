using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeEducation
{
    /// <summary>
    /// 用户教育经历仓储
    /// </summary>
    public interface IEmployeeEducationRepository : IRepository<EmployeeEducationEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="employeeId">人员编号</param>
        /// <returns></returns>
        Task<IList<EmployeeEducationEntity>> Query(int employeeId);
    }
}

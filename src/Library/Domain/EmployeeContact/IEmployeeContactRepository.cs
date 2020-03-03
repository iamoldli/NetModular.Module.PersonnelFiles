using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeContact
{
    /// <summary>
    /// 用户联系信息仓储
    /// </summary>
    public interface IEmployeeContactRepository : IRepository<EmployeeContactEntity>
    {
        /// <summary>
        /// 查询指定人员的联系信息
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<EmployeeContactEntity> GetByEmployee(int employeeId);
    }
}

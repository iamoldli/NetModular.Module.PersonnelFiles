using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeePersonal
{
    /// <summary>
    /// 人员个人信息仓储
    /// </summary>
    public interface IEmployeePersonalRepository : IRepository<EmployeePersonalEntity>
    {
        /// <summary>
        /// 根据人员编号查询个人信息
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<EmployeePersonalEntity> GetByEmployee(int employeeId);
    }
}

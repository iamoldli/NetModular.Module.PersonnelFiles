using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeLeaveInfo
{
    /// <summary>
    /// 人员离职信息仓储
    /// </summary>
    public interface IEmployeeLeaveInfoRepository : IRepository<EmployeeLeaveInfoEntity>
    {
        /// <summary>
        /// 根据人员编号查询离职信息
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<EmployeeLeaveInfoEntity> GetByEmployeeId(int employeeId);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.PersonnelFiles.Domain.Employee;
using NetModular.Module.PersonnelFiles.Domain.EmployeeLatestSelect.Models;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeLatestSelect
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeLatestSelectRepository : IRepository<EmployeeLatestSelectEntity>
    {
        /// <summary>
        /// 查询最近列表
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<EmployeeEntity>> Query(int employeeId, EmployeeLatestSelectQueryModel model);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="relationId"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        Task<EmployeeLatestSelectEntity> Get(int employeeId, int relationId, IUnitOfWork uow);
    }
}

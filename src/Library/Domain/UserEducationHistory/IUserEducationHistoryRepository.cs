using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.PersonnelFiles.Domain.UserEducationHistory.Models;

namespace NetModular.Module.PersonnelFiles.Domain.UserEducationHistory
{
    /// <summary>
    /// 用户教育经历仓储
    /// </summary>
    public interface IUserEducationHistoryRepository : IRepository<UserEducationHistoryEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<UserEducationHistoryEntity>> Query(UserEducationHistoryQueryModel model);
    }
}

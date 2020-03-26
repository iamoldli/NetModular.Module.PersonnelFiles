using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.PersonnelFiles.Domain.Position.Models;

namespace NetModular.Module.PersonnelFiles.Domain.Position
{
    /// <summary>
    /// 岗位仓储
    /// </summary>
    public interface IPositionRepository : IRepository<PositionEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<PositionEntity>> Query(PositionQueryModel model);

        /// <summary>
        /// 名称是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsName(string name, int? id = null);

        /// <summary>
        /// 编码是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsCode(string code, int? id = null);
    }
}

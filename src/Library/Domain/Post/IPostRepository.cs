using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Module.PersonnelFiles.Domain.Post.Models;

namespace NetModular.Module.PersonnelFiles.Domain.Post
{
    /// <summary>
    /// 岗位仓储
    /// </summary>
    public interface IPostRepository : IRepository<PostEntity>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<PostEntity>> Query(PostQueryModel model);

        /// <summary>
        /// 是否存在关联职位
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns></returns>
        Task<bool> ExistsPosition(int positionId);

        /// <summary>
        /// 名称是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> ExistsName(string name, int? id = null);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Admin.Domain.Account;
using NetModular.Module.PersonnelFiles.Domain.Position;
using NetModular.Module.PersonnelFiles.Domain.Post;
using NetModular.Module.PersonnelFiles.Domain.Post.Models;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class PostRepository : RepositoryAbstract<PostEntity>, IPostRepository
    {
        public PostRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<PostEntity>> Query(PostQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();
            query.WhereNotNull(model.PositionId, m => m.PositionId == model.PositionId.Value);
            query.WhereNotNull(model.Name, m => m.Name.Contains(model.Name) || m.ShortName.Contains(model.Name));

            var joinQuery = query.LeftJoin<PositionEntity>((x, y) => x.PositionId == y.Id).LeftJoin<AccountEntity>((x, y, z) => x.CreatedBy == z.Id);
            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((x, y, z) => x.Id);
            }
            joinQuery.Select((x, y, z) => new { x, PositionName = y.Name, Creator = z.Name });

            var result = await joinQuery.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }

        public Task<bool> ExistsPosition(int positionId)
        {
            return Db.Find(m => m.PositionId == positionId).ExistsAsync();
        }

        public Task<bool> ExistsName(string name, int? id = null)
        {
            var query = Db.Find(m => m.Name == name);
            query.WhereNotNull(id, m => m.Id != id.Value);
            return query.ExistsAsync();
        }
    }
}

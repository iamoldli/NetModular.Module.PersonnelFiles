using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Admin.Domain.Account;
using NetModular.Module.PersonnelFiles.Domain.Position;
using NetModular.Module.PersonnelFiles.Domain.Position.Models;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class PositionRepository : RepositoryAbstract<PositionEntity>, IPositionRepository
    {
        public PositionRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<PositionEntity>> Query(PositionQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();
            query.WhereNotNull(model.Name, m => m.Name.Contains(model.Name));
            query.WhereNotNull(model.Code, m => m.Code == model.Code);

            var joinQuery = query.LeftJoin<AccountEntity>((x, y) => x.CreatedBy == y.Id);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((x, y) => x.Id);
            }

            joinQuery.Select((x, y) => new { x, Creator = y.Name });

            var result = await joinQuery.PaginationAsync(paging);
            model.TotalCount = paging.TotalCount;

            return result;
        }

        public Task<bool> ExistsName(string name, int? id = null)
        {
            var query = Db.Find(m => m.Name == name);
            query.WhereNotNull(id, m => m.Id != id.Value);
            return query.ExistsAsync();
        }

        public Task<bool> ExistsCode(string code, int? id = null)
        {
            var query = Db.Find(m => m.Code == code);
            query.WhereNotNull(id, m => m.Id != id.Value);
            return query.ExistsAsync();
        }
    }
}

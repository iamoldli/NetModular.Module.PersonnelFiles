using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.PersonnelFiles.Domain.UserWorkHistory;
using NetModular.Module.PersonnelFiles.Domain.UserWorkHistory.Models;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class UserWorkHistoryRepository : RepositoryAbstract<UserWorkHistoryEntity>, IUserWorkHistoryRepository
    {
        public UserWorkHistoryRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<UserWorkHistoryEntity>> Query(UserWorkHistoryQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find(m => m.UserId == model.UserId);
            query.WhereNotNull(model.EnterpriseName, m => m.EnterpriseName.Contains(model.EnterpriseName));

            if (!paging.OrderBy.Any())
            {
                query.OrderByDescending(m => m.Id);
            }

            var result = await query.PaginationAsync(paging);

            model.TotalCount = paging.TotalCount;

            return result;
        }
    }
}

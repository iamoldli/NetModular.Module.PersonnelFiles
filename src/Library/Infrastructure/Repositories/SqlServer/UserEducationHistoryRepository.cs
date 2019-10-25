using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.PersonnelFiles.Domain.UserEducationHistory;
using NetModular.Module.PersonnelFiles.Domain.UserEducationHistory.Models;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class UserEducationHistoryRepository : RepositoryAbstract<UserEducationHistoryEntity>, IUserEducationHistoryRepository
    {
        public UserEducationHistoryRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<UserEducationHistoryEntity>> Query(UserEducationHistoryQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find(m => m.UserId == model.UserId);
            query.WhereNotNull(model.SchoolName, m => m.SchoolName.Contains(model.SchoolName));

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

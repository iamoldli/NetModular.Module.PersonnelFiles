using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Admin.Domain.Account;
using NetModular.Module.PersonnelFiles.Domain.Department;
using NetModular.Module.PersonnelFiles.Domain.Position;
using NetModular.Module.PersonnelFiles.Domain.User;
using NetModular.Module.PersonnelFiles.Domain.User.Models;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class UserRepository : RepositoryAbstract<UserEntity>, IUserRepository
    {
        public UserRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<UserEntity>> Query(UserQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();
            query.WhereNotNull(model.Name, m => m.Name.Contains(model.Name));
            query.WhereIf(model.Number != null && model.Number > 0, m => m.JobNo == model.Number);

            var joinQuery = query.LeftJoin<AccountEntity>((x, y) => x.CreatedBy == y.Id)
                .LeftJoin<DepartmentEntity>((t1, t2, t3) => t1.DepartmentId == t3.Id)
                .LeftJoin<PositionEntity>((t1, t2, t3, t4) => t1.PositionId == t4.Id);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((t1, t2, t3, t4) => t1.Id);
            }

            joinQuery.Select((t1, t2, t3, t4) => new { t1, Creator = t2.Name, DepartmentName = t3.Name, PositionName = t4.Name });

            var result = await joinQuery.PaginationAsync(paging);
            model.TotalCount = paging.TotalCount;

            return result;
        }

        public Task<bool> ExistsBindDept(Guid departmentId)
        {
            return Db.Find(m => m.DepartmentId == departmentId).ExistsAsync();
        }

        public Task<bool> ExistsBindPosition(Guid positionId)
        {
            return Db.Find(m => m.DepartmentId == positionId).ExistsAsync();
        }

        public Task<int> GetMaxJobNumber()
        {
            return Db.Find().MaxAsync(m => m.JobNo);
        }
    }
}

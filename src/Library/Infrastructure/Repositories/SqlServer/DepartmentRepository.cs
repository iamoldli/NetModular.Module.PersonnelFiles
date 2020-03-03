using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Admin.Domain.Account;
using NetModular.Module.PersonnelFiles.Domain.Department;
using NetModular.Module.PersonnelFiles.Domain.Department.Models;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class DepartmentRepository : RepositoryAbstract<DepartmentEntity>, IDepartmentRepository
    {
        public DepartmentRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<DepartmentEntity>> Query(DepartmentQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find(m => m.ParentId == model.ParentId);

            query.WhereNotNull(model.Name, m => m.Name.Contains(model.Name));
            query.WhereNotNull(model.Code, m => m.Code == model.Code);

            var joinQuery = query.LeftJoin<AccountEntity>((x, y) => x.CreatedBy == y.Id);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderBy((x, y) => x.Sort);
            }

            joinQuery.Select((x, y) => new { x, Creator = y.Name });

            var result = await joinQuery.PaginationAsync(paging);
            model.TotalCount = paging.TotalCount;

            return result;
        }

        public Task<bool> ExistsName(string name, Guid parentId, Guid? id = null)
        {
            var query = Db.Find(m => m.Name == name && m.ParentId == parentId);
            query.WhereNotNull(id, m => m.Id != id.Value);

            return query.ExistsAsync();
        }

        public Task<bool> ExistsCode(string code, Guid? id = null)
        {
            var query = Db.Find(m => m.Code == code);
            query.WhereNotNull(id, m => m.Id != id.Value);
            return query.ExistsAsync();
        }

        public Task<bool> ExistsChildren(Guid parentId)
        {
            return Db.Find(m => m.ParentId == parentId).ExistsAsync();
        }
    }
}

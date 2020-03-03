using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.PersonnelFiles.Domain.Department;
using NetModular.Module.PersonnelFiles.Domain.Employee;
using NetModular.Module.PersonnelFiles.Domain.EmployeeLatestSelect;
using NetModular.Module.PersonnelFiles.Domain.EmployeeLatestSelect.Models;
using NetModular.Module.PersonnelFiles.Domain.Post;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class EmployeeLatestSelectRepository : RepositoryAbstract<EmployeeLatestSelectEntity>, IEmployeeLatestSelectRepository
    {
        public EmployeeLatestSelectRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<EmployeeEntity>> Query(int employeeId, EmployeeLatestSelectQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find(m => m.EmployeeId == employeeId);
            var joinQuery = query.LeftJoin<EmployeeEntity>((t1, t2) => t1.RelationId == t2.Id && t2.Status == EmployeeStatus.Work)
                  .LeftJoin<DepartmentEntity>((t1, t2, t3) => t2.DepartmentId == t3.Id)
                .LeftJoin<PostEntity>((t1, t2, t3, t4) => t2.PostId == t4.Id);

            joinQuery.WhereNotNull(model.Name, (t1, t2, t3, t4) => t2.Name.Contains(model.Name));
            joinQuery.OrderByDescending((t1, t2, t3, t4) => t1.Timestamp);
            joinQuery.Select((t1, t2, t3, t4) => new { t2, DepartmentPath = t3.FullPath, PostName = t4.Name });

            var list = await joinQuery.PaginationAsync<EmployeeEntity>(paging);
            model.TotalCount = paging.TotalCount;
            return list;
        }

        public Task<EmployeeLatestSelectEntity> Get(int employeeId, int relationId, IUnitOfWork uow)
        {
            return GetAsync(m => m.EmployeeId == employeeId && m.RelationId == relationId, uow);
        }
    }
}

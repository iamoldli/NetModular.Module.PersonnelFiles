using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Lib.Data.Query;
using NetModular.Module.Admin.Domain.Account;
using NetModular.Module.PersonnelFiles.Domain.Department;
using NetModular.Module.PersonnelFiles.Domain.Employee;
using NetModular.Module.PersonnelFiles.Domain.Employee.Models;
using NetModular.Module.PersonnelFiles.Domain.Post;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class EmployeeRepository : RepositoryAbstract<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContext context) : base(context)
        {
        }

        public async Task<IList<EmployeeEntity>> Query(EmployeeQueryModel model)
        {
            var paging = model.Paging();

            var query = Db.Find();
            query.WhereIf(model.DepartmentId != null && model.DepartmentId.Value.NotEmpty(), m => m.DepartmentId == model.DepartmentId);
            query.WhereNotNull(model.Name, m => m.Name.Contains(model.Name));
            query.WhereNotNull(model.JobNo, m => m.Id == model.JobNo.Value);

            var joinQuery = query.LeftJoin<AccountEntity>((x, y) => x.CreatedBy == y.Id)
                .LeftJoin<DepartmentEntity>((t1, t2, t3) => t1.DepartmentId == t3.Id)
                .LeftJoin<PostEntity>((t1, t2, t3, t4) => t1.PostId == t4.Id);

            if (!paging.OrderBy.Any())
            {
                joinQuery.OrderByDescending((t1, t2, t3, t4) => t1.Id);
            }

            joinQuery.Select((t1, t2, t3, t4) => new { t1, Creator = t2.Name, DepartmentPath = t3.FullPath, PostName = t4.Name });

            var result = await joinQuery.PaginationAsync(paging);
            model.TotalCount = paging.TotalCount;

            return result;
        }

        public Task<bool> ExistsBindDept(Guid departmentId)
        {
            return Db.Find(m => m.DepartmentId == departmentId).ExistsAsync();
        }

        public Task<bool> ExistsBindPost(int postId)
        {
            return Db.Find(m => m.PostId == postId).ExistsAsync();
        }

        public Task<bool> UpdateLeaveStatus(int id, IUnitOfWork uow)
        {
            return Db.Find(m => m.Id == id).UseUow(uow).UpdateAsync(m => new EmployeeEntity
            {
                Status = EmployeeStatus.Leave
            });
        }

        public Task<EmployeeEntity> GetByAccountId(Guid accountId)
        {
            return GetAsync(m => m.AccountId == accountId);
        }

        public Task<IList<EmployeeEntity>> QueryByDepartment(Guid departmentId)
        {
            return Db.Find(m => m.DepartmentId == departmentId)
                .LeftJoin<PostEntity>((t1, t2) => t1.PostId == t2.Id)
                .LeftJoin<DepartmentEntity>((t1, t2, t3) => t1.DepartmentId == t3.Id)
                .OrderBy((t1, t2, t3) => t1.Sort)
                .Select((t1, t2, t3) => new { t1, PostName = t2.Name, DepartmentPath = t3.FullPath }).ToListAsync();
        }

        public Task<EmployeeEntity> GetWidthExtend(int id)
        {
            return Db.Find(m => m.Id == id)
                .LeftJoin<PostEntity>((t1, t2) => t1.PostId == t2.Id)
                .LeftJoin<DepartmentEntity>((t1, t2, t3) => t1.DepartmentId == t3.Id)
                .OrderBy((t1, t2, t3) => t1.Sort)
                .Select((t1, t2, t3) => new { t1, PostName = t2.Name, DepartmentPath = t3.FullPath }).FirstAsync();
        }
    }
}

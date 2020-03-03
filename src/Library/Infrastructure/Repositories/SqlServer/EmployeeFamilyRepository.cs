using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Module.PersonnelFiles.Domain.EmployeeFamily;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class EmployeeFamilyRepository : RepositoryAbstract<EmployeeFamilyEntity>, IEmployeeFamilyRepository
    {
        public EmployeeFamilyRepository(IDbContext context) : base(context)
        {
        }

        public Task<IList<EmployeeFamilyEntity>> Query(int employeeId)
        {
            return Db.Find(m => m.EmployeeId == employeeId).ToListAsync();
        }
    }
}

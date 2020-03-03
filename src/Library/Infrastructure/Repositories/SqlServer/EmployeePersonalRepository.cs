using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Module.PersonnelFiles.Domain.EmployeePersonal;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class EmployeePersonalRepository : RepositoryAbstract<EmployeePersonalEntity>, IEmployeePersonalRepository
    {
        public EmployeePersonalRepository(IDbContext context) : base(context)
        {
        }

        public Task<EmployeePersonalEntity> GetByEmployee(int employeeId)
        {
            return GetAsync(m => m.EmployeeId == employeeId);
        }
    }
}

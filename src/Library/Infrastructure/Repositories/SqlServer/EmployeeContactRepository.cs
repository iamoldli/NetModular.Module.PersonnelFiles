using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Module.PersonnelFiles.Domain.EmployeeContact;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class EmployeeContactRepository : RepositoryAbstract<EmployeeContactEntity>, IEmployeeContactRepository
    {
        public EmployeeContactRepository(IDbContext context) : base(context)
        {
        }

        public Task<EmployeeContactEntity> GetByEmployee(int employeeId)
        {
            return GetAsync(m => m.EmployeeId == employeeId);
        }
    }
}

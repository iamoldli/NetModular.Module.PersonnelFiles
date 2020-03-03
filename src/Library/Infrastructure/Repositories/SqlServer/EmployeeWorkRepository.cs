using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Module.PersonnelFiles.Domain.EmployeeWork;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class EmployeeWorkRepository : RepositoryAbstract<EmployeeWorkEntity>, IEmployeeWorkRepository
    {
        public EmployeeWorkRepository(IDbContext context) : base(context)
        {
        }

        public Task<IList<EmployeeWorkEntity>> Query(int employeeId)
        {
            return Db.Find(m => m.EmployeeId == employeeId).ToListAsync();
        }
    }
}

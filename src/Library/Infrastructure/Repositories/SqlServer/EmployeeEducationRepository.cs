using System.Collections.Generic;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Module.PersonnelFiles.Domain.EmployeeEducation;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class EmployeeEducationRepository : RepositoryAbstract<EmployeeEducationEntity>, IEmployeeEducationRepository
    {
        public EmployeeEducationRepository(IDbContext context) : base(context)
        {
        }

        public Task<IList<EmployeeEducationEntity>> Query(int employeeId)
        {
            return Db.Find(m => m.EmployeeId == employeeId).ToListAsync();
        }
    }
}

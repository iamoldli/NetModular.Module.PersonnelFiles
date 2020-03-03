using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Module.PersonnelFiles.Domain.EmployeeLeaveInfo;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class EmployeeLeaveInfoRepository : RepositoryAbstract<EmployeeLeaveInfoEntity>, IEmployeeLeaveInfoRepository
    {
        public EmployeeLeaveInfoRepository(IDbContext context) : base(context)
        {
        }

        public Task<EmployeeLeaveInfoEntity> GetByEmployeeId(int employeeId)
        {
            return GetAsync(m => m.EmployeeId == employeeId);
        }
    }
}

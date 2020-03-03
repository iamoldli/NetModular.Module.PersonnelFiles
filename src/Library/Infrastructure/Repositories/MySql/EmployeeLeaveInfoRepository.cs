using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.MySql
{
    public class EmployeeLeaveInfoRepository : SqlServer.EmployeeLeaveInfoRepository
    {
        public EmployeeLeaveInfoRepository(IDbContext context) : base(context)
        {
        }
    }
}

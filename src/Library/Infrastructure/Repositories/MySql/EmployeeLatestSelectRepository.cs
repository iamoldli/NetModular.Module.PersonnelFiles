using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.MySql
{
    public class EmployeeLatestSelectRepository : SqlServer.EmployeeLatestSelectRepository
    {
        public EmployeeLatestSelectRepository(IDbContext context) : base(context)
        {
        }
    }
}

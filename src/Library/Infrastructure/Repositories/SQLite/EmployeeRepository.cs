using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SQLite
{
    public class EmployeeRepository : SqlServer.EmployeeRepository
    {
        public EmployeeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}

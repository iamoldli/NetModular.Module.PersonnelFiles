using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.PostgreSQL
{
    public class EmployeeRepository : SqlServer.EmployeeRepository
    {
        public EmployeeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
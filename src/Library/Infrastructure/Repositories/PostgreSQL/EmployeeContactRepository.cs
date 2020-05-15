using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.PostgreSQL
{
    public class EmployeeContactRepository : SqlServer.EmployeeContactRepository
    {
        public EmployeeContactRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
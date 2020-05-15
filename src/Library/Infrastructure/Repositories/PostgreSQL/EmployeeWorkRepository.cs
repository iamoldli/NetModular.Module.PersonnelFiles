using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.PostgreSQL
{
    public class EmployeeWorkRepository : SqlServer.EmployeeWorkRepository
    {
        public EmployeeWorkRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
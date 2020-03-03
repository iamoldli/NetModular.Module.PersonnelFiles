using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.MySql
{
    public class EmployeeWorkRepository : SqlServer.EmployeeWorkRepository
    {
        public EmployeeWorkRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SQLite
{
    public class EmployeeContactRepository : SqlServer.EmployeeContactRepository
    {
        public EmployeeContactRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}

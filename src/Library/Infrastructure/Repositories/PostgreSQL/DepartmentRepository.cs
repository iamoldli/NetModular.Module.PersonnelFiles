using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.PostgreSQL
{
    public class DepartmentRepository : SqlServer.DepartmentRepository
    {
        public DepartmentRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
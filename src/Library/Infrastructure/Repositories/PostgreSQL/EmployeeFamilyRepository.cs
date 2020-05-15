using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.PostgreSQL
{
    public class EmployeeFamilyRepository : SqlServer.EmployeeFamilyRepository
    {
        public EmployeeFamilyRepository(IDbContext context) : base(context)
        {
        }
    }
}

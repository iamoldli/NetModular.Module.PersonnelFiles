using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SQLite
{
    public class EmployeeFamilyRepository : SqlServer.EmployeeFamilyRepository
    {
        public EmployeeFamilyRepository(IDbContext context) : base(context)
        {
        }
    }
}

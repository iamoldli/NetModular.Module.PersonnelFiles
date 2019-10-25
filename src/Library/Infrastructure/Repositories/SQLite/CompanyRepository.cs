using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SQLite
{
    public class CompanyRepository : SqlServer.CompanyRepository
    {
        public CompanyRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}

using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SQLite
{
    public class UserRepository : SqlServer.UserRepository
    {
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}

using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.MySql
{
    public class UserContactRepository : SqlServer.UserContactRepository
    {
        public UserContactRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
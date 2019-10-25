using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.MySql
{
    public class UserWorkHistoryRepository : SqlServer.UserWorkHistoryRepository
    {
        public UserWorkHistoryRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
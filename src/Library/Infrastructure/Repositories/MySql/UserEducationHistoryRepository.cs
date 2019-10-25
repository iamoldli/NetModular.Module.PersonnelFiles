using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.MySql
{
    public class UserEducationHistoryRepository : SqlServer.UserEducationHistoryRepository
    {
        public UserEducationHistoryRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SQLite
{
    public class PostRepository : SqlServer.PostRepository
    {
        public PostRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}

using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.PostgreSQL
{
    public class PostRepository : SqlServer.PostRepository
    {
        public PostRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
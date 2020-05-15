using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.PostgreSQL
{
    public class PositionRepository : SqlServer.PositionRepository
    {
        public PositionRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
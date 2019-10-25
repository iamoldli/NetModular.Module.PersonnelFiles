using NetModular.Lib.Data.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SQLite
{
    public class PositionRepository : SqlServer.PositionRepository
    {
        public PositionRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}

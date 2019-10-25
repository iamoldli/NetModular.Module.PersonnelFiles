using System;
using System.Threading.Tasks;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;
using NetModular.Module.PersonnelFiles.Domain.UserContact;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories.SqlServer
{
    public class UserContactRepository : RepositoryAbstract<UserContactEntity>, IUserContactRepository
    {
        public UserContactRepository(IDbContext context) : base(context)
        {
        }

        public Task<UserContactEntity> GetByUser(Guid userId)
        {
            return Db.Find(m => m.UserId == userId).FirstAsync();
        }
    }
}

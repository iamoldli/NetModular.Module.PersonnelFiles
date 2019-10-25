using System;
using NetModular.Lib.Data.Abstractions;
using NetModular.Lib.Data.Core;

namespace NetModular.Module.PersonnelFiles.Infrastructure.Repositories
{
    public class PersonnelFilesDbContext : DbContext
    {
        public PersonnelFilesDbContext(IDbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }
    }
}

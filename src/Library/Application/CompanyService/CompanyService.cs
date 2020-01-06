using System;
using System.Threading.Tasks;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.Admin.Domain.Config;
using NetModular.Module.PersonnelFiles.Infrastructure;

namespace NetModular.Module.PersonnelFiles.Application.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly IConfigRepository _configRepository;

        public CompanyService(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        public Task<IResultModel> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IResultModel> Update(CompanyInfo model)
        {
            throw new NotImplementedException();
        }
    }
}

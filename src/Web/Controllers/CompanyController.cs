using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Lib.Config.Abstractions;
using NetModular.Module.PersonnelFiles.Infrastructure;

namespace NetModular.Module.PersonnelFiles.Web.Controllers
{
    /// <summary>
    /// 公司单位
    /// </summary>
    public class CompanyController : ModuleController
    {
        private readonly IConfigProvider _configProvider;

        public CompanyController(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        [HttpGet]
        [Description("获取公司单位信息")]
        [Common]
        public IResultModel Get()
        {
            var config = _configProvider.Get<PersonnelFilesConfig>();
            var company = new
            {
                Name = config.CompanyName,
                Address = config.CompanyAddress,
                Contact = config.CompanyContact,
                Phone = config.CompanyPhone,
                Fax = config.CompanyFax
            };
            return ResultModel.Success(company);
        }
    }
}

using NetModular.Lib.Options.Abstraction;

namespace NetModular.Module.PersonnelFiles.Infrastructure
{
    /// <summary>
    /// 人事档案配置项
    /// </summary>
    public class PersonnelFilesOptions : IModuleOptions
    {
        /// <summary>
        /// 公司单位名称
        /// </summary>
        [ModuleOptionDefinition("公司单位名称")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 公司单位地址
        /// </summary>
        [ModuleOptionDefinition("公司单位地址")]
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 公司单位联系人
        /// </summary>
        [ModuleOptionDefinition("公司单位联系人")]
        public string CompanyContact { get; set; }

        /// <summary>
        /// 公司单位电话
        /// </summary>
        [ModuleOptionDefinition("公司单位联系电话")]
        public string CompanyPhone { get; set; }

        /// <summary>
        /// 公司单位传真
        /// </summary>
        [ModuleOptionDefinition("公司单位传真")]
        public string CompanyFax { get; set; }

        public IModuleOptions Copy()
        {
            return new PersonnelFilesOptions
            {
                CompanyName = CompanyName,
                CompanyAddress = CompanyAddress,
                CompanyContact = CompanyContact,
                CompanyFax = CompanyFax,
                CompanyPhone = CompanyPhone
            };
        }
    }
}

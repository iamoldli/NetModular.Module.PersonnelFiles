using NetModular.Lib.Config.Abstractions;

namespace NetModular.Module.PersonnelFiles.Infrastructure
{
    /// <summary>
    /// 人事档案配置项
    /// </summary>
    public class PersonnelFilesConfig : IConfig
    {
        /// <summary>
        /// 公司单位名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 公司单位地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 公司单位联系人
        /// </summary>
        public string CompanyContact { get; set; }

        /// <summary>
        /// 公司单位电话
        /// </summary>
        public string CompanyPhone { get; set; }

        /// <summary>
        /// 公司单位传真
        /// </summary>
        public string CompanyFax { get; set; }
    }
}

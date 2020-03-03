using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeContact
{
    /// <summary>
    /// 人员通讯信息
    /// </summary>
    [Table("Employee_Contact")]
    public partial class EmployeeContactEntity : EntityBase<int>
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        [Nullable]
        public string Phone { get; set; }

        /// <summary>
        /// 办公室电话
        /// </summary>
        [Nullable]
        public string OfficePhone { get; set; }

        /// <summary>
        /// 其他电话
        /// </summary>
        [Nullable]
        public string OtherPhone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [Nullable]
        public string Fax { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Length(250)]
        [Nullable]
        public string Email { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        [Nullable]
        [Length(20)]
        public string QQ { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        [Nullable]
        public string WeChat { get; set; }

        /// <summary>
        /// 钉钉
        /// </summary>
        [Nullable]
        public string DingDing { get; set; }

        /// <summary>
        /// 支付宝
        /// </summary>
        [Nullable]
        public string Alipay { get; set; }

        #region ==现居住地==

        /// <summary>
        /// 省份编码
        /// </summary>
        [Nullable]
        [Length(12)]
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        [Nullable]
        public string ProvinceName { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        [Length(12)]
        [Nullable]
        public string CityCode { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [Nullable]
        public string CityName { get; set; }

        /// <summary>
        /// 区县编码
        /// </summary>
        [Length(12)]
        [Nullable]
        public string AreaCode { get; set; }

        /// <summary>
        /// 区县名称
        /// </summary>
        [Nullable]
        public string AreaName { get; set; }

        /// <summary>
        /// 城镇编码
        /// </summary>
        [Length(12)]
        [Nullable]
        public string TownCode { get; set; }

        /// <summary>
        /// 城镇名称
        /// </summary>
        [Length(100)]
        [Nullable]
        public string TownName { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        [Length(200)]
        [Nullable]
        public string Address { get; set; }

        #endregion
    }
}

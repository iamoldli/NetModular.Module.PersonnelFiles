using System.ComponentModel.DataAnnotations;
using NetModular.Lib.Utils.Core.Models;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels
{
    public class EmployeeContactUpdateModel
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        [Required(ErrorMessage = "请选择人员")]
        [Range(1, int.MaxValue, ErrorMessage = "人员编号无效")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 办公室电话
        /// </summary>
        public string OfficePhone { get; set; }

        /// <summary>
        /// 其他电话
        /// </summary>
        public string OtherPhone { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 微信
        /// </summary>
        public string WeChat { get; set; }

        /// <summary>
        /// 钉钉
        /// </summary>
        public string DingDing { get; set; }

        /// <summary>
        /// 支付宝
        /// </summary>
        public string Alipay { get; set; }

        /// <summary>
        /// 区域信息
        /// </summary>
        public AreaSelectModel Area { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }
    }
}

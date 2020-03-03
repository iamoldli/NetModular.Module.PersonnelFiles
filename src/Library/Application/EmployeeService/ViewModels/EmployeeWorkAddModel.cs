using System;
using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels
{
    /// <summary>
    /// 工作经历信息添加模型
    /// </summary>
    public class EmployeeWorkAddModel
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        [Required(ErrorMessage = "请选择人员")]
        [Range(1, int.MaxValue, ErrorMessage = "人员编号无效")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Required(ErrorMessage = "请输入公司名称")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 联系人手机号
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 离开原因
        /// </summary>
        public string LeaveReason { get; set; }
    }
}

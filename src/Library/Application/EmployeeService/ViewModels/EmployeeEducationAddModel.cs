using System;
using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels
{
    /// <summary>
    /// 教育背景信息添加模型
    /// </summary>
    public class EmployeeEducationAddModel
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        [Required(ErrorMessage = "请选择人员")]
        [Range(1, int.MaxValue, ErrorMessage = "人员编号无效")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        [Required(ErrorMessage = "请填写学校名称")]
        public string SchoolName { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Profession { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels
{
    /// <summary>
    /// 人员离职模型
    /// </summary>
    public class EmployeeLeaveModel
    {
        [Required(ErrorMessage = "请选择人员")]
        [Range(1, int.MaxValue, ErrorMessage = "请选择人员")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 离职类型
        /// </summary>
        [Required(ErrorMessage = "请选择离职类型")]
        public string Type { get; set; }

        /// <summary>
        /// 离职原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        [Required(ErrorMessage = "请选择离职日期")]
        public DateTime ApplyDate { get; set; }

        /// <summary>
        /// 离岗日期
        /// </summary>
        [Required(ErrorMessage = "请选择离岗日期")]
        public DateTime LeaveDate { get; set; }
    }
}

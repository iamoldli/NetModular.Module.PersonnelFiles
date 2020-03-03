using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels
{
    /// <summary>
    /// 家庭情况信息添加模型
    /// </summary>
    public class EmployeeFamilyAddModel
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        [Required(ErrorMessage = "请选择人员")]
        [Range(1, int.MaxValue, ErrorMessage = "人员编号无效")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 关系
        /// </summary>
        [Required(ErrorMessage = "请填写关系")]
        public string Relation { get; set; }

        /// <summary>
        /// 工作单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Lib.Utils.Core.Enums;
using NetModular.Lib.Utils.Core.Validations;
using NetModular.Module.PersonnelFiles.Domain.Employee;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels
{
    /// <summary>
    /// 员工基本信息编辑模型
    /// </summary>
    public class EmployeeBaseUpdateModel
    {
        [Required(ErrorMessage = "请选择人员")]
        [Range(1, int.MaxValue, ErrorMessage = "请选择人员")]
        public int Id { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        [NotEmpty(ErrorMessage = "请选择部门")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "请输入姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 性质
        /// </summary>
        public EmployeeNature Nature { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// 照片(附件编号)
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// 岗位编号
        /// </summary>
        public int? PostId { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}

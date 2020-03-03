using System;
using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.DepartmentService.ViewModels
{
    /// <summary>
    /// 部门添加模型
    /// </summary>
    public class DepartmentAddModel
    {
        /// <summary>
        /// 父节点
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入部门名称")]
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}

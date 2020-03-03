using System;
using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.DepartmentService.ViewModels
{
    /// <summary>
    /// 部门编辑模型
    /// </summary>
    public class DepartmentUpdateModel : DepartmentAddModel
    {
        [Required(ErrorMessage = "请选择要修改的部门")]
        public Guid Id { get; set; }
    }
}

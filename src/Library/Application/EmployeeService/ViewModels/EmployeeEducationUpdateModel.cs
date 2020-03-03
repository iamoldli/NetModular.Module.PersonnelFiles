using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels
{
    /// <summary>
    /// 教育背景信息更新模型
    /// </summary>
    public class EmployeeEducationUpdateModel : EmployeeEducationAddModel
    {
        [Required(ErrorMessage = "请选择数据")]
        [Range(1, int.MaxValue, ErrorMessage = "请选择数据")]
        public int Id { get; set; }
    }
}

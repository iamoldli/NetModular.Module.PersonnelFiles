using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels
{
    /// <summary>
    /// 工作经历信息更新模型
    /// </summary>
    public class EmployeeWorkUpdateModel : EmployeeWorkAddModel
    {
        [Required(ErrorMessage = "请选择数据")]
        [Range(1, int.MaxValue, ErrorMessage = "请选择数据")]
        public int Id { get; set; }
    }
}

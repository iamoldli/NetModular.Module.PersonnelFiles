using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels
{
    /// <summary>
    /// 家庭情况信息更新模型
    /// </summary>
    public class EmployeeFamilyUpdateModel : EmployeeFamilyAddModel
    {
        [Required(ErrorMessage = "请选择数据")]
        [Range(1, int.MaxValue, ErrorMessage = "请选择数据")]
        public int Id { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.PositionService.ViewModels
{
    /// <summary>
    /// 岗位添加模型
    /// </summary>
    public class PositionUpdateModel : PositionAddModel
    {
        [Required(ErrorMessage = "请选择要修改的数据")]
        [Range(1, int.MaxValue, ErrorMessage = "请选择要修改的数据")]
        public int Id { get; set; }
    }
}

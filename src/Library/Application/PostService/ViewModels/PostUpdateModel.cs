using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.PostService.ViewModels
{
    /// <summary>
    /// 岗位添加模型
    /// </summary>
    public class PostUpdateModel : PostAddModel
    {
        [Required(ErrorMessage = "请选择要修改的岗位")]
        [Range(1, int.MaxValue, ErrorMessage = "请选择数据")]
        public int Id { get; set; }
    }
}

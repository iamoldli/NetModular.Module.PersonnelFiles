using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.UserWorkHistoryService.ViewModels
{
    public class UserWorkHistoryUpdateModel : UserWorkHistoryAddModel
    {
        [Required(ErrorMessage = "请选择数据")]
        public int Id { get; set; }
    }
}

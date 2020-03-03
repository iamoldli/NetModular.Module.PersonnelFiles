using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.PostService.ViewModels
{
    /// <summary>
    /// 岗位添加模型
    /// </summary>
    public class PostAddModel
    {
        /// <summary>
        /// 职位编号
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "请选择职位")]
        public int PositionId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入名称")]
        public string Name { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 职责
        /// </summary>
        public string Responsibility { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}

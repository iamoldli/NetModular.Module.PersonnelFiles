using System.ComponentModel.DataAnnotations;

namespace NetModular.Module.PersonnelFiles.Application.PositionService.ViewModels
{
    /// <summary>
    /// 岗位添加模型
    /// </summary>
    public class PositionAddModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "请输入岗位名称")]
        public string Name { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}

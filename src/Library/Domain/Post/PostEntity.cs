using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.PersonnelFiles.Domain.Post
{
    /// <summary>
    /// 岗位
    /// </summary>
    [Table("Post")]
    public partial class PostEntity : EntityBase<int>
    {
        /// <summary>
        /// 职位编号
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Length(100)]
        public string Name { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
		[Nullable]
        public string ShortName { get; set; }

        /// <summary>
        /// 职责
        /// </summary>
		[Nullable]
        [Length(500)]
        public string Responsibility { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
		[Nullable]
        [Length(500)]
        public string Remarks { get; set; }
    }
}

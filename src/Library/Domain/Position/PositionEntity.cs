using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.PersonnelFiles.Domain.Position
{
    /// <summary>
    /// 职位
    /// </summary>
    [Table("Position")]
    public partial class PositionEntity : EntityBase<int>
    {
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
        /// 编码
        /// </summary>
        [Nullable]
        public string Code { get; set; }
    }
}

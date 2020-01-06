using System;
using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.PersonnelFiles.Domain.Department
{
    /// <summary>
    /// 部门
    /// </summary>
    [Table("Department")]
    public partial class DepartmentEntity : EntityBase
    {
        /// <summary>
        /// 父级ID
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Length(100)]
        public string Name { get; set; }

        /// <summary>
        /// 负责人ID
        /// </summary>
        public Guid Leader { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get; set; }
    }
}

using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeLatestSelect
{
    [Table("Employee_Latest_Select")]
    public class EmployeeLatestSelectEntity : Entity<int>
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 关联人员编号
        /// </summary>
        public int RelationId { get; set; }

        /// <summary>
        /// 最近选择时间戳
        /// </summary>
        public long Timestamp { get; set; }
    }
}

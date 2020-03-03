using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeFamily
{
    /// <summary>
    /// 人员家庭情况信息
    /// </summary>
    [Table("Employee_Family")]
    public class EmployeeFamilyEntity : EntityBase<int>
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 关系
        /// </summary>
        public string Relation { get; set; }

        /// <summary>
        /// 工作单位
        /// </summary>
        [Nullable]
        [Length(200)]
        public string Unit { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [Nullable]
        public string Post { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [Nullable]
        public string Phone { get; set; }
    }
}

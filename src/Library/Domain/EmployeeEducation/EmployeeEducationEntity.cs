using System;
using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeEducation
{
    /// <summary>
    /// 人员教育背景
    /// </summary>
    [Table("Employee_Education")]
    public class EmployeeEducationEntity : EntityBase<int>
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        [Length(100)]
        public string SchoolName { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [Nullable]
        public string Level { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        [Length(100)]
        [Nullable]
        public string Profession { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Length(500)]
        [Nullable]
        public string Remarks { get; set; }
    }
}

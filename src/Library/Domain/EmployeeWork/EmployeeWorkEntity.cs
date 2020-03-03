using System;
using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeeWork
{
    /// <summary>
    /// 人员工作经历
    /// </summary>
    [Table("Employee_Work")]
    public class EmployeeWorkEntity : EntityBase<int>
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [Length(100)]
        public string CompanyName { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [Nullable]
        public string Post { get; set; }
        
        /// <summary>
        /// 联系人
        /// </summary>
        [Nullable]
        public string Contact { get; set; }

        /// <summary>
        /// 联系人手机号
        /// </summary>
        [Nullable]
        public string ContactPhone { get; set; }

        /// <summary>
        /// 离开原因
        /// </summary>
        [Length(500)]
        [Nullable]
        public string LeaveReason { get; set; }
    }
}

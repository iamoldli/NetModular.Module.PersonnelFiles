using System;
using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Data.Core.Entities.Extend;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeePersonal
{
    /// <summary>
    /// 人员个人信息
    /// </summary>
    [Table("Employee_Personal")]
    public class EmployeePersonalEntity : EntityBase<int>
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Nullable]
        public string Nation { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [Nullable]
        public string Native { get; set; }

        /// <summary>
        /// 户口
        /// </summary>
        [Nullable]
        public string RegisterPlace { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Nullable]
        public string IdCard { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        [Nullable]
        public string PoliticsStatus { get; set; }

        /// <summary>
        /// 学历(数据字典)
        /// </summary>
        [Nullable]
        public string EducationLevel { get; set; }

        /// <summary>
        /// 学历名称
        /// </summary>
        [Nullable]
        public string EducationLevelName { get; set; }

        /// <summary>
        /// 学位
        /// </summary>
        [Nullable]
        public string Degree { get; set; }

        /// <summary>
        /// 健康状况
        /// </summary>
        public HealthStatus HealthStatus { get; set; }

        /// <summary>
        /// 身高(cm)
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 体重(kg)
        /// </summary>
        public int Weight { get; set; }
    }
}

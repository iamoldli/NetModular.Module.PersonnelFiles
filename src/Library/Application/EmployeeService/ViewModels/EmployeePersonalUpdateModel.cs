using System;
using System.ComponentModel.DataAnnotations;
using NetModular.Module.PersonnelFiles.Domain.EmployeePersonal;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ViewModels
{
    public class EmployeePersonalUpdateModel
    {
        /// <summary>
        /// 人员编号
        /// </summary>
        [Required(ErrorMessage = "请选择人员")]
        [Range(1, int.MaxValue, ErrorMessage = "人员编号无效")]
        public int EmployeeId { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string Native { get; set; }

        /// <summary>
        /// 户口
        /// </summary>
        public string RegisterPlace { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCard { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public string PoliticsStatus { get; set; }

        /// <summary>
        /// 学历(字典值)
        /// </summary>
        public string EducationLevel { get; set; }

        /// <summary>
        /// 学历名称
        /// </summary>
        public string EducationLevelName { get; set; }

        /// <summary>
        /// 学位
        /// </summary>
        public string Degree { get; set; }

        /// <summary>
        /// 健康状况
        /// </summary>
        public HealthStatus HealthStatus { get; set; }

        /// <summary>
        /// 身高(cm)
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// 体重(kg)
        /// </summary>
        public int? Weight { get; set; }
    }
}

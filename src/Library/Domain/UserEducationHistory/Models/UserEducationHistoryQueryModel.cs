using System;
using System.ComponentModel.DataAnnotations;
using  NetModular.Lib.Data.Query;

namespace  NetModular.Module.PersonnelFiles.Domain.UserEducationHistory.Models
{
    public class UserEducationHistoryQueryModel : QueryModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [Required(ErrorMessage = "请选择用户")]
        public Guid UserId { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { get; set; }
    }
}

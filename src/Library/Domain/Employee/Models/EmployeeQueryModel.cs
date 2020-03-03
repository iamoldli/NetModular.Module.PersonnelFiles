using System;
using NetModular.Lib.Data.Query;

namespace NetModular.Module.PersonnelFiles.Domain.Employee.Models
{
    public class EmployeeQueryModel : QueryModel
    {
        /// <summary>
        /// 部门编号
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public int? JobNo { get; set; }
    }
}

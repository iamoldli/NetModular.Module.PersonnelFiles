using System;
using NetModular.Lib.Data.Query;

namespace NetModular.Module.PersonnelFiles.Domain.Department.Models
{
    public class DepartmentQueryModel : QueryModel
    {
        /// <summary>
        /// 父节点
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}

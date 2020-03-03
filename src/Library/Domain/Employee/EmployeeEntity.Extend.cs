using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Utils.Core.Extensions;

namespace NetModular.Module.PersonnelFiles.Domain.Employee
{
    public partial class EmployeeEntity
    {
        /// <summary>
        /// 工号(1000000 + Id)
        /// </summary>
        [Ignore]
        public int JobNo => 1000000 + Id;

        /// <summary>
        /// 部门路径
        /// </summary>
        [Ignore]
        public string DepartmentPath { get; set; }

        /// <summary>
        /// 岗位名称
        /// </summary>
        [Ignore]
        public string PostName { get; set; }

        /// <summary>
        /// 性别名称
        /// </summary>
        [Ignore]
        public string SexName => Sex.ToDescription();

        /// <summary>
        /// 性质名称
        /// </summary>
        [Ignore]
        public string NatureName => Nature.ToDescription();

        /// <summary>
        /// 状态名称
        /// </summary>
        [Ignore]
        public string StatusName => Status.ToDescription();
    }
}

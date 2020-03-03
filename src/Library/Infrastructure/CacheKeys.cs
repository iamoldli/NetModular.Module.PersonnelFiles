using System.ComponentModel;

namespace NetModular.Module.PersonnelFiles.Infrastructure
{
    public static class CacheKeys
    {
        /// <summary>
        /// 部门树
        /// </summary>
        [Description("部门树")]
        public const string DepartmentTree = "PERSONNELFILES:DEPARTMENT:TREE";

        /// <summary>
        /// 岗位下拉列表
        /// </summary>
        [Description("岗位下拉列表")]
        public const string PostSelect = "PERSONNELFILES:POST:SELECT";

        /// <summary>
        /// 人员基本信息
        /// </summary>
        [Description("人员基本信息")]
        public const string EmployeeBaseInfo = "PERSONNELFILES:EMPLOYEE:BASEINFO:";

        /// <summary>
        /// 人员树
        /// </summary>
        [Description("人员树")]
        public const string EmployeeTree = "PERSONNELFILES:EMPLOYEE:TREE";
    }
}

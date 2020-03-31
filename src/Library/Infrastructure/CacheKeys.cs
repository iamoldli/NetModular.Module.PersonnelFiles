using System.ComponentModel;

namespace NetModular.Module.PersonnelFiles.Infrastructure
{
    public static class CacheKeys
    {
        /// <summary>
        /// 部门树
        /// </summary>
        [Description("部门树")]
        public const string DEPARTMENT_TREE = "PERSONNEL_FILES:DEPARTMENT_TREE";

        /// <summary>
        /// 岗位下拉列表
        /// </summary>
        [Description("岗位下拉列表")]
        public const string POST_SELECT = "PERSONNEL_FILES:POST_SELECT";

        /// <summary>
        /// 人员基本信息
        /// </summary>
        [Description("人员基本信息")]
        public const string EMPLOYEE_BASE_INFO = "PERSONNEL_FILES:EMPLOYEE:BASE_INFO";

        /// <summary>
        /// 人员树
        /// </summary>
        [Description("人员树")]
        public const string EMPLOYEE_TREE = "PERSONNEL_FILES:EMPLOYEE:TREE";
    }
}

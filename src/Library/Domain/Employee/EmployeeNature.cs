using System.ComponentModel;

namespace NetModular.Module.PersonnelFiles.Domain.Employee
{
    /// <summary>
    /// 员工性质
    /// </summary>
    public enum EmployeeNature
    {
        /// <summary>
        /// 试用
        /// </summary>
        [Description("试用")]
        Probation,
        /// <summary>
        /// 正式
        /// </summary>
        [Description("正式")]
        Official,
        /// <summary>
        /// 临时
        /// </summary>
        [Description("临时")]
        Temp,
        /// <summary>
        /// 外包
        /// </summary>
        [Description("外包")]
        Outsource,
        /// <summary>
        /// 外聘
        /// </summary>
        [Description("外聘")]
        Hire
    }

}

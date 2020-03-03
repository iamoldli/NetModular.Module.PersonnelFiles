using System.ComponentModel;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeePersonal
{
    /// <summary>
    /// 婚姻状况
    /// </summary>
    public enum MaritalStatus
    {
        /// <summary>
        /// 未婚
        /// </summary>
        [Description("未婚")]
        Unmarried,
        /// <summary>
        /// 已婚
        /// </summary>
        [Description("已婚")]
        Married,
        /// <summary>
        /// 离异
        /// </summary>
        [Description("离异")]
        Divorced
    }
}

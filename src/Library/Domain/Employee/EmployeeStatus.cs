using System.ComponentModel;

namespace NetModular.Module.PersonnelFiles.Domain.Employee
{
    /// <summary>
    /// 员工状态
    /// </summary>
    public enum EmployeeStatus
    {
        /// <summary>
        /// 在职
        /// </summary>
        [Description("在职")]
        Work,
        /// <summary>
        /// 离职
        /// </summary>
        [Description("离职")]
        Leave
    }
}

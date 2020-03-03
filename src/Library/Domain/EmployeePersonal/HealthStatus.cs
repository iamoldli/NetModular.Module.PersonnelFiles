using System.ComponentModel;

namespace NetModular.Module.PersonnelFiles.Domain.EmployeePersonal
{
    /// <summary>
    /// 健康状况
    /// </summary>
    public enum HealthStatus
    {
        /// <summary>
        /// 优秀
        /// </summary>
        [Description("优秀")]
        Excellence,
        /// <summary>
        /// 良好
        /// </summary>
        [Description("良好")]
        Well,
        /// <summary>
        /// 一般
        /// </summary>
        [Description("一般")]
        General,
        /// <summary>
        /// 较差
        /// </summary>
        [Description("较差")]
        Worse
    }
}

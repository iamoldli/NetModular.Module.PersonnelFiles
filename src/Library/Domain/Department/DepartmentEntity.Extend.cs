using NetModular.Lib.Data.Abstractions.Attributes;

namespace NetModular.Module.PersonnelFiles.Domain.Department
{
    public partial class DepartmentEntity
    {
        /// <summary>
        /// ����������
        /// </summary>
        [Ignore]
        public string LeaderName { get; set; }
    }
}

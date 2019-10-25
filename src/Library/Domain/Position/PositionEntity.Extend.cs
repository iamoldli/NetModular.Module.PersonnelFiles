using NetModular.Lib.Data.Abstractions.Attributes;

namespace NetModular.Module.PersonnelFiles.Domain.Position
{
    public partial class PositionEntity
    {
        /// <summary>
        /// ��������
        /// </summary>
        [Ignore]
        public string DepartmentName { get; set; }

        /// <summary>
        /// ��˾��λ
        /// </summary>
        [Ignore]
        public string CompanyName { get; set; }
    }
}

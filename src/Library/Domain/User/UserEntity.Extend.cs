using NetModular.Lib.Data.Abstractions.Attributes;
using NetModular.Lib.Utils.Core.Extensions;

namespace NetModular.Module.PersonnelFiles.Domain.User
{
    public partial class UserEntity
    {
        /// <summary>
        /// ��������
        /// </summary>
        [Ignore]
        public string DepartmentName { get; set; }

        /// <summary>
        /// ��λ����
        /// </summary>
        [Ignore]
        public string PositionName { get; set; }

        /// <summary>
        /// �Ա�����
        /// </summary>
        [Ignore]
        public string SexName => Sex.ToDescription();
    }
}

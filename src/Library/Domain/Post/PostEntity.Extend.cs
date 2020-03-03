using NetModular.Lib.Data.Abstractions.Attributes;

namespace NetModular.Module.PersonnelFiles.Domain.Post
{
    public partial class PostEntity
    {
        /// <summary>
        /// Ö°Î»Ãû³Æ
        /// </summary>
        [Ignore]
        public string PositionName { get; set; }
    }
}

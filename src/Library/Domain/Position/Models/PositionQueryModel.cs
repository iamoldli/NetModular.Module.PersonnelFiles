using NetModular.Lib.Data.Query;

namespace NetModular.Module.PersonnelFiles.Domain.Position.Models
{
    public class PositionQueryModel : QueryModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}

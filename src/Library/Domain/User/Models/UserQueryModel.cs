using NetModular.Lib.Data.Query;

namespace NetModular.Module.PersonnelFiles.Domain.User.Models
{
    public class UserQueryModel : QueryModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public int? Number { get; set; }
    }
}

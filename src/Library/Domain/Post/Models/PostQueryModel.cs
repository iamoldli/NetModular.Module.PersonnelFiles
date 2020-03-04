using System;
using NetModular.Lib.Data.Query;

namespace  NetModular.Module.PersonnelFiles.Domain.Post.Models
{
    public class PostQueryModel : QueryModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}

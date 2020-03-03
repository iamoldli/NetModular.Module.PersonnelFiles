using NetModular.Lib.Utils.Core.Enums;

namespace NetModular.Module.PersonnelFiles.Application.EmployeeService.ResultModels
{
    /// <summary>
    /// 人员树返回结果
    /// </summary>
    public class EmployeeTreeResultModel
    {
        /// <summary>
        /// 源编号
        /// </summary>
        public string SourceId { get; set; }

        /// <summary>
        /// 类型 0：部门 1：人员
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 人员岗位名称
        /// </summary>
        public string PostName { get; set; }

        /// <summary>
        /// 人员性别
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// 人员部门路径
        /// </summary>
        public string DepartmentPath { get; set; }
    }
}

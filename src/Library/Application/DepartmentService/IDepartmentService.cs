using System;
using System.Threading.Tasks;
using NetModular.Module.PersonnelFiles.Application.DepartmentService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Department.Models;

namespace NetModular.Module.PersonnelFiles.Application.DepartmentService
{
    /// <summary>
    /// 部门服务
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// 查询部门树
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> GetTree();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Query(DepartmentQueryModel model);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Add(DepartmentAddModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<IResultModel> Delete(Guid id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IResultModel> Edit(Guid id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Update(DepartmentUpdateModel model);
    }
}

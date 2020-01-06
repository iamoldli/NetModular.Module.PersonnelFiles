using System.Threading.Tasks;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.PersonnelFiles.Infrastructure;

namespace NetModular.Module.PersonnelFiles.Application.CompanyService
{
    /// <summary>
    /// 公司单位
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// 获取单位信息
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> Get();

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> Update(CompanyInfo model);
    }
}

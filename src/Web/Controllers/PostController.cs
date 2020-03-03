using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Lib.Auth.Web.Attributes;
using NetModular.Lib.Utils.Core.Result;
using NetModular.Module.PersonnelFiles.Application.PostService;
using NetModular.Module.PersonnelFiles.Application.PostService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Post.Models;

namespace NetModular.Module.PersonnelFiles.Web.Controllers
{
    [Description("岗位管理")]
    public class PostController : ModuleController
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]PostQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(PostAddModel model)
        {
            return _service.Add(model);
        }

        [HttpDelete]
        [Description("删除")]
        public Task<IResultModel> Delete([BindRequired]int id)
        {
            return _service.Delete(id);
        }

        [HttpGet]
        [Description("编辑")]
        public Task<IResultModel> Edit([BindRequired]int id)
        {
            return _service.Edit(id);
        }

        [HttpPost]
        [Description("修改")]
        public Task<IResultModel> Update(PostUpdateModel model)
        {
            return _service.Update(model);
        }

        [HttpGet]
        [Common]
        [Description("下拉列表")]
        public Task<IResultModel> Select()
        {
            return _service.Select();
        }
    }
}

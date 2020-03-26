using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NetModular.Module.PersonnelFiles.Application.PositionService;
using NetModular.Module.PersonnelFiles.Application.PositionService.ViewModels;
using NetModular.Module.PersonnelFiles.Domain.Position.Models;

namespace NetModular.Module.PersonnelFiles.Web.Controllers
{
    [Description("职位管理")]
    public class PositionController : ModuleController
    {
        private readonly IPositionService _service;

        public PositionController(IPositionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Description("查询")]
        public Task<IResultModel> Query([FromQuery]PositionQueryModel model)
        {
            return _service.Query(model);
        }

        [HttpPost]
        [Description("添加")]
        public Task<IResultModel> Add(PositionAddModel model)
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
        public Task<IResultModel> Update(PositionUpdateModel model)
        {
            return _service.Update(model);
        }

        [HttpGet]
        [Description("修改")]
        public Task<IResultModel> Get([BindRequired]int id)
        {
            return _service.Get(id);
        }
    }
}

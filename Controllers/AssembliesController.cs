using System.Web.Mvc;
using Connect.DNN.Modules.ApiBrowser.Common;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.DNN.Modules.ApiBrowser.Controllers
{
    public class AssembliesController : ApiBrowserMvcController
    {
        [HttpGet]
        public ActionResult Assembly(int componentId)
        {
            var c = ComponentRepository.Instance.GetComponent(ModuleContext.ModuleId, componentId);
            return View(c);
        }

    }
}

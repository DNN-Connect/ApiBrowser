using System.Web.Mvc;
using Connect.DNN.Modules.ApiBrowser.Common;
using Connect.ApiBrowser.Core.Repositories;

namespace Connect.DNN.Modules.ApiBrowser.Controllers
{
    public class NamespacesController : ApiBrowserMvcController
    {
        [HttpGet]
        public ActionResult Namespace(int namespaceId)
        {
            var n = ApiNamespaceRepository.Instance.GetApiNamespace(ModuleContext.ModuleId, namespaceId);
            return View(n);
        }

    }
}

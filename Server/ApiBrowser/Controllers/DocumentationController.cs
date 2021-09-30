using System.Web.Mvc;
using Connect.DNN.Modules.ApiBrowser.Common;
using Connect.ApiBrowser.Core.Models.Documentations;

namespace Connect.DNN.Modules.ApiBrowser.Controllers
{
    public class DocumentationController : ApiBrowserMvcController
    {
        [HttpGet]
        [ApiBrowserMvcAuthorize(SecurityLevel = SecurityAccessLevel.Comment)]
        public ActionResult Edit(string name)
        {
            var d = new Documentation()
            {
                ModuleId = ActiveModule.ModuleID,
                FullName = name
            };
            return View(d);
        }
        [HttpGet]
        [ApiBrowserMvcAuthorize(SecurityLevel = SecurityAccessLevel.Moderate)]
        public ActionResult Moderate()
        {
            return View();
        }
    }
}

using System.Web.Mvc;
using Connect.DNN.Modules.ApiBrowser.Common;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.Models.Documentations;

namespace Connect.DNN.Modules.ApiBrowser.Controllers
{
    public class DocumentationController : ApiBrowserMvcController
    {
        [HttpGet]
        public ActionResult Edit(int classId, int memberId)
        {
            var d = new Documentation()
            {
                ClassId = classId,
                MemberId = memberId
            };
            return View(d);
        }
    }
}

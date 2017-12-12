using System.Linq;
using System.Web.Mvc;
using Connect.DNN.Modules.ApiBrowser.Common;
using Connect.ApiBrowser.Core.Repositories;
using Connect.ApiBrowser.Core.Models;

namespace Connect.DNN.Modules.ApiBrowser.Controllers
{
    public class NamespacesController : ApiBrowserMvcController
    {
        [HttpGet]
        public ActionResult Namespace(string view)
        {
            var s = new ViewSelection();
            s.SelectedNamespace = ApiNamespaceRepository.Instance.GetNearestApiNamespace(ModuleContext.ModuleId, view);
            if (s.SelectedNamespace != null)
            {
                if (s.SelectedNamespace.NamespaceName.Length < view.Length)
                {
                    var remainder = view.Substring(s.SelectedNamespace.NamespaceName.Length + 1);
                    var segments = remainder.Split('.');
                    s.SelectedClass = ApiClassRepository.Instance.GetApiClassesByApiNamespace(s.SelectedNamespace.NamespaceId).FirstOrDefault(c => c.ClassName.ToLower() == segments[0].ToLower());
                    if (s.SelectedClass != null && segments.Length > 1)
                    {
                        s.SelectedMember = MemberRepository.Instance.GetMembersByApiClass(s.SelectedClass.ClassId).FirstOrDefault(m => m.MemberName.ToLower() == segments[1].ToLower());
                    }
                }
            }
            return View(s);
        }

    }
}

using DotNetNuke.Web.Mvc.Framework.Controllers;
using DotNetNuke.Web.Mvc.Routing;
using System.Web.Mvc;
using System.Web.Routing;

namespace Connect.DNN.Modules.ApiBrowser.Common
{
    public class ApiBrowserMvcController : DnnController
    {

        private ContextHelper _apibrowserModuleContext;
        public ContextHelper ApiBrowserModuleContext
        {
            get { return _apibrowserModuleContext ?? (_apibrowserModuleContext = new ContextHelper(this)); }
        }

    }
}
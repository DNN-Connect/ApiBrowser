using DotNetNuke.Web.Api;

namespace Connect.DNN.Modules.ApiBrowser.Api
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("Connect/ApiBrowser", "ApiBrowserMap1", "{controller}/{action}", null, null, new[] { "Connect.DNN.Modules.ApiBrowser.Api" });
            mapRouteManager.MapHttpRoute("Connect/ApiBrowser", "ApiBrowserMap2", "{controller}/{action}/{id}", null, new { id = "-?\\d+" }, new[] { "Connect.DNN.Modules.ApiBrowser.Api" });
        }
    }
}
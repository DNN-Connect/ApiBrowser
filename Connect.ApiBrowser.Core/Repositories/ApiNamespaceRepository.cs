using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.ApiNamespaces;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Repositories
{
    public partial class ApiNamespaceRepository : ServiceLocator<IApiNamespaceRepository, ApiNamespaceRepository>, IApiNamespaceRepository
    {
        public ApiNamespace GetOrCreateNamespace(int moduleId, string namespaceName)
        {
            var fullNamespace = "";
            ApiNamespace crtNamespace = null;
            foreach (var segment in namespaceName.Split('.'))
            {
                fullNamespace = (fullNamespace + "." + segment).TrimStart('.');
                crtNamespace = Sprocs.GetOrCreateNamespace(moduleId, crtNamespace == null ? 0 : crtNamespace.NamespaceId, fullNamespace, segment);
            }
            return crtNamespace;
        }
    }
    public partial interface IApiNamespaceRepository
    {
        ApiNamespace GetOrCreateNamespace(int moduleId, string namespaceName);
    }
}


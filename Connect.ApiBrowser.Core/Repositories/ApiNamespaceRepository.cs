using System.Linq;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.ApiNamespaces;
using Connect.ApiBrowser.Core.Data;
using DotNetNuke.Data;

namespace Connect.ApiBrowser.Core.Repositories
{
    public partial class ApiNamespaceRepository : ServiceLocator<IApiNamespaceRepository, ApiNamespaceRepository>, IApiNamespaceRepository
    {
        public ApiNamespace GetNearestApiNamespace(int moduleId, string fullQualifier)
        {
            ApiNamespace res = null;
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiNamespace>();
                var crtQualifier = fullQualifier;
                while (true)
                {
                    var crt = rep.Find("WHERE NamespaceName=@0", crtQualifier).FirstOrDefault();
                    if (crt != null)
                    {
                        res = crt;
                        break;
                    }
                    if (crtQualifier.IndexOf('.')<0)
                    {
                        break;
                    }
                    crtQualifier = crtQualifier.Substring(0, crtQualifier.LastIndexOf('.'));
                }
            }
            return res;
        }
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
        ApiNamespace GetNearestApiNamespace(int moduleId, string fullQualifier);
        ApiNamespace GetOrCreateNamespace(int moduleId, string namespaceName);
    }
}


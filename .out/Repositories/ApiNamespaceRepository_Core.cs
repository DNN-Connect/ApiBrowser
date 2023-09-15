using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.ApiNamespaces;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class ApiNamespaceRepository : ServiceLocator<IApiNamespaceRepository, ApiNamespaceRepository>, IApiNamespaceRepository
 {
        protected override Func<IApiNamespaceRepository> GetFactory()
        {
            return () => new ApiNamespaceRepository();
        }
        public IEnumerable<ApiNamespace> GetApiNamespaces(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiNamespace>();
                return rep.Get(moduleId);
            }
        }
        public ApiNamespace GetApiNamespace(int moduleId, int namespaceId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiNamespace>();
                return rep.GetById(namespaceId, moduleId);
            }
        }
        public ApiNamespace AddApiNamespace(ApiNamespace apiNamespace)
        {
            Requires.NotNull(apiNamespace);
            Requires.PropertyNotNegative(apiNamespace, "ModuleId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiNamespace>();
                rep.Insert(apiNamespace);
            }
            return apiNamespace;
        }
        public void DeleteApiNamespace(ApiNamespace apiNamespace)
        {
            Requires.NotNull(apiNamespace);
            Requires.PropertyNotNegative(apiNamespace, "ApiNamespaceId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiNamespace>();
                rep.Delete(apiNamespace);
            }
        }
        public void DeleteApiNamespace(int moduleId, int namespaceId)
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiNamespace>();
                rep.Delete("WHERE ModuleId = @0 AND NamespaceId = @1", moduleId, namespaceId);
            }
        }
        public void UpdateApiNamespace(ApiNamespace apiNamespace)
        {
            Requires.NotNull(apiNamespace);
            Requires.PropertyNotNegative(apiNamespace, "ApiNamespaceId");
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<ApiNamespace>();
                rep.Update(apiNamespace);
            }
        } 
    }
    public partial interface IApiNamespaceRepository
    {
        IEnumerable<ApiNamespace> GetApiNamespaces(int moduleId);
        ApiNamespace GetApiNamespace(int moduleId, int namespaceId);
        ApiNamespace AddApiNamespace(ApiNamespace apiNamespace);
        void DeleteApiNamespace(ApiNamespace apiNamespace);
        void DeleteApiNamespace(int moduleId, int namespaceId);
        void UpdateApiNamespace(ApiNamespace apiNamespace);
    }
}


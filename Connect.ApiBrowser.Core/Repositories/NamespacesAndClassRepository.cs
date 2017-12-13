using System.Collections.Generic;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.NamespacesAndClasses;
using DotNetNuke.Collections;

namespace Connect.ApiBrowser.Core.Repositories
{
    public partial class NamespacesAndClassRepository : ServiceLocator<INamespacesAndClassRepository, NamespacesAndClassRepository>, INamespacesAndClassRepository
    {
        public IPagedList<NamespacesAndClass> List(int moduleId, bool classes, bool namespaces, string searchText, int pageIndex, int pageSize)
        {
            using (var context = DataContext.Instance())
            {
                var repo = context.GetRepository<NamespacesAndClass>();
                var wheres = new List<string>();
                wheres.Add(string.Format("ModuleId={0}", moduleId));
                if (classes && !namespaces)
                {
                    wheres.Add("IsClass=1");
                }
                else if (!classes && namespaces)
                {
                    wheres.Add("IsClass=0");
                }
                if (!string.IsNullOrEmpty(searchText))
                {
                    var ps = new DotNetNuke.Security.PortalSecurity();
                    wheres.Add(string.Format("(Name LIKE '%{0}%' OR Description LIKE '%{0}%')", ps.InputFilter(searchText, DotNetNuke.Security.PortalSecurity.FilterFlag.NoSQL)));
                }
                var sql = string.Format("WHERE {0} ORDER BY Name", string.Join(" AND ", wheres));
                return repo.Find(pageIndex, pageSize, sql);
            }
        }
    }
    public partial interface INamespacesAndClassRepository
    {
        IPagedList<NamespacesAndClass> List(int moduleId, bool classes, bool namespaces, string searchText, int pageIndex, int pageSize);
    }
}


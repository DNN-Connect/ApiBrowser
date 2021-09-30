using System.Collections.Generic;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.NamespacesClassesAndMembers;
using DotNetNuke.Collections;

namespace Connect.ApiBrowser.Core.Repositories
{
    public partial class NamespacesClassesAndMemberRepository : ServiceLocator<INamespacesClassesAndMemberRepository, NamespacesClassesAndMemberRepository>, INamespacesClassesAndMemberRepository
    {
        public IPagedList<NamespacesClassesAndMember> List(int moduleId, int mainType, int subType, int status, string searchText, int pageIndex, int pageSize)
        {
            using (var context = DataContext.Instance())
            {
                var repo = context.GetRepository<NamespacesClassesAndMember>();
                var wheres = new List<string>();
                wheres.Add(string.Format("ModuleId={0}", moduleId));
                if (mainType > -1)
                {
                    wheres.Add(string.Format("MainType={0}", mainType));
                }
                if (subType > -1)
                {
                    wheres.Add(string.Format("SubType={0}", subType));
                }
                if (status > -1)
                {
                    switch (status)
                    {
                        case 0: // non deprecated
                            wheres.Add("IsDeprecated=0");
                            break;
                        case 1: // deprecated
                            wheres.Add("IsDeprecated=1");
                            break;
                        case 2: // removed
                            wheres.Add("(IsDeprecated=1 AND (NOT DisappearedInVersion IS NULL))");
                            break;
                    }
                    wheres.Add(string.Format("MainType={0}", mainType));
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
    public partial interface INamespacesClassesAndMemberRepository
    {
        IPagedList<NamespacesClassesAndMember> List(int moduleId, int mainType, int subType, int status, string searchText, int pageIndex, int pageSize);
    }
}


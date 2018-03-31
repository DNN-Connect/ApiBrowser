using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.NamespacesClassesAndMembers;

namespace Connect.ApiBrowser.Core.Repositories
{

	public partial class NamespacesClassesAndMemberRepository : ServiceLocator<INamespacesClassesAndMemberRepository, NamespacesClassesAndMemberRepository>, INamespacesClassesAndMemberRepository
 {
        protected override Func<INamespacesClassesAndMemberRepository> GetFactory()
        {
            return () => new NamespacesClassesAndMemberRepository();
        }
        public IEnumerable<NamespacesClassesAndMember> GetNamespacesClassesAndMembers()
        {
            using (var context = DataContext.Instance())
            {
                var rep = context.GetRepository<NamespacesClassesAndMember>();
                return rep.Get();
            }
        }
    }
    public partial interface INamespacesClassesAndMemberRepository
    {
        IEnumerable<NamespacesClassesAndMember> GetNamespacesClassesAndMembers();
    }
}


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
    }
    public partial interface INamespacesClassesAndMemberRepository
    {
    }
}


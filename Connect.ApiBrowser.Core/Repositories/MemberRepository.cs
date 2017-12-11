using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.Members;

namespace Connect.ApiBrowser.Core.Repositories
{
	public partial class MemberRepository : ServiceLocator<IMemberRepository, MemberRepository>, IMemberRepository
    {
    }
    public partial interface IMemberRepository
    {
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.MemberCodeBlocks;

namespace Connect.ApiBrowser.Core.Repositories
{
	public partial class MemberCodeBlockRepository : ServiceLocator<IMemberCodeBlockRepository, MemberCodeBlockRepository>, IMemberCodeBlockRepository
    {
    }
    public partial interface IMemberCodeBlockRepository
    {
    }
}


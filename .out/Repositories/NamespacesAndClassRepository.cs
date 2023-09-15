using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.NamespacesAndClasses;

namespace Connect.ApiBrowser.Core.Repositories
{
	public partial class NamespacesAndClassRepository : ServiceLocator<INamespacesAndClassRepository, NamespacesAndClassRepository>, INamespacesAndClassRepository
    {
    }
    public partial interface INamespacesAndClassRepository
    {
    }
}


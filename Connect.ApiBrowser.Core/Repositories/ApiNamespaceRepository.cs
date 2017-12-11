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
    }
    public partial interface IApiNamespaceRepository
    {
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.Dependencies;

namespace Connect.ApiBrowser.Core.Repositories
{
	public partial class DependencyRepository : ServiceLocator<IDependencyRepository, DependencyRepository>, IDependencyRepository
    {
    }
    public partial interface IDependencyRepository
    {
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.Components;

namespace Connect.ApiBrowser.Core.Repositories
{
	public partial class ComponentRepository : ServiceLocator<IComponentRepository, ComponentRepository>, IComponentRepository
    {
    }
    public partial interface IComponentRepository
    {
    }
}


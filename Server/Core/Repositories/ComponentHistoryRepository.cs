using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.ComponentHistories;

namespace Connect.ApiBrowser.Core.Repositories
{
	public partial class ComponentHistoryRepository : ServiceLocator<IComponentHistoryRepository, ComponentHistoryRepository>, IComponentHistoryRepository
    {
    }
    public partial interface IComponentHistoryRepository
    {
    }
}


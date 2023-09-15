using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.References;

namespace Connect.ApiBrowser.Core.Repositories
{
	public partial class ReferenceRepository : ServiceLocator<IReferenceRepository, ReferenceRepository>, IReferenceRepository
    {
    }
    public partial interface IReferenceRepository
    {
    }
}


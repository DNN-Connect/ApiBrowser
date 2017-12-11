using System;
using System.Collections.Generic;
using System.Linq;
using DotNetNuke.Common;
using DotNetNuke.Data;
using DotNetNuke.Framework;
using Connect.ApiBrowser.Core.Models.ApiClasses;

namespace Connect.ApiBrowser.Core.Repositories
{
    public partial class ApiClassRepository : ServiceLocator<IApiClassRepository, ApiClassRepository>, IApiClassRepository
    {
    }
    public partial interface IApiClassRepository
    {
    }
}


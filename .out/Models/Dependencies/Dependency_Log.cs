using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.Dependencies
{
    public partial class DependencyBase
 {
        public List<LogChange> CompareWith(DependencyBase dependency)
        {
      var res = new List<LogChange>();
            if (DependencyId != dependency.DependencyId)
        res.Add(new LogChange("DependencyId",this.DependencyId, dependency.DependencyId));
            if (ComponentHistoryId != dependency.ComponentHistoryId)
        res.Add(new LogChange("ComponentHistoryId",this.ComponentHistoryId, dependency.ComponentHistoryId));
            if (FullName != dependency.FullName)
        res.Add(new LogChange("FullName",this.FullName, dependency.FullName));
            if (Version != dependency.Version)
        res.Add(new LogChange("Version",this.Version, dependency.Version));
            if (VersionNormalized != dependency.VersionNormalized)
        res.Add(new LogChange("VersionNormalized",this.VersionNormalized, dependency.VersionNormalized));
            if (Name != dependency.Name)
        res.Add(new LogChange("Name",this.Name, dependency.Name));
            if (DepComponentHistoryId != dependency.DepComponentHistoryId)
        res.Add(new LogChange("DepComponentHistoryId",this.DepComponentHistoryId, dependency.DepComponentHistoryId));

            return res;
        }
 }
}


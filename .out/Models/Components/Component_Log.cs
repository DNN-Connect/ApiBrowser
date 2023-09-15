using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.Components
{
    public partial class Component
 {
        public List<LogChange> CompareWith(Component component)
        {
      var res = new List<LogChange>();
            if (ComponentId != component.ComponentId)
        res.Add(new LogChange("ComponentId",this.ComponentId, component.ComponentId));
            if (ModuleId != component.ModuleId)
        res.Add(new LogChange("ModuleId",this.ModuleId, component.ModuleId));
            if (ComponentName != component.ComponentName)
        res.Add(new LogChange("ComponentName",this.ComponentName, component.ComponentName));
            if (LatestVersion != component.LatestVersion)
        res.Add(new LogChange("LatestVersion",this.LatestVersion, component.LatestVersion));
            if (Description != component.Description)
        res.Add(new LogChange("Description",this.Description, component.Description));

            return res;
        }
 }
}


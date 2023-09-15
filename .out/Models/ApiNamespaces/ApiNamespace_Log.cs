using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.ApiNamespaces
{
    public partial class ApiNamespace
 {
        public List<LogChange> CompareWith(ApiNamespace apiNamespace)
        {
      var res = new List<LogChange>();
            if (NamespaceId != apiNamespace.NamespaceId)
        res.Add(new LogChange("NamespaceId",this.NamespaceId, apiNamespace.NamespaceId));
            if (ParentId != apiNamespace.ParentId)
        res.Add(new LogChange("ParentId",this.ParentId, apiNamespace.ParentId));
            if (ModuleId != apiNamespace.ModuleId)
        res.Add(new LogChange("ModuleId",this.ModuleId, apiNamespace.ModuleId));
            if (NamespaceName != apiNamespace.NamespaceName)
        res.Add(new LogChange("NamespaceName",this.NamespaceName, apiNamespace.NamespaceName));
            if (LastQualifier != apiNamespace.LastQualifier)
        res.Add(new LogChange("LastQualifier",this.LastQualifier, apiNamespace.LastQualifier));
            if (Description != apiNamespace.Description)
        res.Add(new LogChange("Description",this.Description, apiNamespace.Description));

            return res;
        }
 }
}


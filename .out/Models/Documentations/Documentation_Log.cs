using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.Documentations
{
    public partial class DocumentationBase
 {
        public List<LogChange> CompareWith(DocumentationBase documentation)
        {
      var res = new List<LogChange>();
            if (DocumentationId != documentation.DocumentationId)
        res.Add(new LogChange("DocumentationId",this.DocumentationId, documentation.DocumentationId));
            if (ModuleId != documentation.ModuleId)
        res.Add(new LogChange("ModuleId",this.ModuleId, documentation.ModuleId));
            if (FullName != documentation.FullName)
        res.Add(new LogChange("FullName",this.FullName, documentation.FullName));
            if (Contents != documentation.Contents)
        res.Add(new LogChange("Contents",this.Contents, documentation.Contents));

            return res;
        }
 }
}


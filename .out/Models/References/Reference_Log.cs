using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.References
{
    public partial class ReferenceBase
 {
        public List<LogChange> CompareWith(ReferenceBase reference)
        {
      var res = new List<LogChange>();
            if (ReferenceId != reference.ReferenceId)
        res.Add(new LogChange("ReferenceId",this.ReferenceId, reference.ReferenceId));
            if (CodeBlockId != reference.CodeBlockId)
        res.Add(new LogChange("CodeBlockId",this.CodeBlockId, reference.CodeBlockId));
            if (FullName != reference.FullName)
        res.Add(new LogChange("FullName",this.FullName, reference.FullName));
            if (Offset != reference.Offset)
        res.Add(new LogChange("Offset",this.Offset, reference.Offset));
            if (ReferencedMemberId != reference.ReferencedMemberId)
        res.Add(new LogChange("ReferencedMemberId",this.ReferencedMemberId, reference.ReferencedMemberId));

            return res;
        }
 }
}


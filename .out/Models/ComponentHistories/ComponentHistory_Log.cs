using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.ComponentHistories
{
    public partial class ComponentHistory
 {
        public List<LogChange> CompareWith(ComponentHistory componentHistory)
        {
      var res = new List<LogChange>();
            if (ComponentHistoryId != componentHistory.ComponentHistoryId)
        res.Add(new LogChange("ComponentHistoryId",this.ComponentHistoryId, componentHistory.ComponentHistoryId));
            if (ComponentId != componentHistory.ComponentId)
        res.Add(new LogChange("ComponentId",this.ComponentId, componentHistory.ComponentId));
            if (Version != componentHistory.Version)
        res.Add(new LogChange("Version",this.Version, componentHistory.Version));
            if (VersionNormalized != componentHistory.VersionNormalized)
        res.Add(new LogChange("VersionNormalized",this.VersionNormalized, componentHistory.VersionNormalized));
            if (FullName != componentHistory.FullName)
        res.Add(new LogChange("FullName",this.FullName, componentHistory.FullName));
            if (CodeLines != componentHistory.CodeLines)
        res.Add(new LogChange("CodeLines",this.CodeLines, componentHistory.CodeLines));
            if (CommentLines != componentHistory.CommentLines)
        res.Add(new LogChange("CommentLines",this.CommentLines, componentHistory.CommentLines));
            if (EmptyLines != componentHistory.EmptyLines)
        res.Add(new LogChange("EmptyLines",this.EmptyLines, componentHistory.EmptyLines));

            return res;
        }
 }
}


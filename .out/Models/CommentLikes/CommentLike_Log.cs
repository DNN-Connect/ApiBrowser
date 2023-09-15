using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.CommentLikes
{
    public partial class CommentLike
 {
        public List<LogChange> CompareWith(CommentLike commentLike)
        {
      var res = new List<LogChange>();
            if (CommentId != commentLike.CommentId)
        res.Add(new LogChange("CommentId",this.CommentId, commentLike.CommentId));
            if (UserId != commentLike.UserId)
        res.Add(new LogChange("UserId",this.UserId, commentLike.UserId));
            if (Datime != commentLike.Datime)
        res.Add(new LogChange("Datime",this.Datime, commentLike.Datime));

            return res;
        }
 }
}


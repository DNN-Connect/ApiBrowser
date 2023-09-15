using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.Comments
{
    public partial class Comment
 {
        public List<LogChange> CompareWith(Comment comment)
        {
      var res = new List<LogChange>();
            if (CommentID != comment.CommentID)
        res.Add(new LogChange("CommentID",this.CommentID, comment.CommentID));
            if (ComponentId != comment.ComponentId)
        res.Add(new LogChange("ComponentId",this.ComponentId, comment.ComponentId));
            if (ItemType != comment.ItemType)
        res.Add(new LogChange("ItemType",this.ItemType, comment.ItemType));
            if (ItemId != comment.ItemId)
        res.Add(new LogChange("ItemId",this.ItemId, comment.ItemId));
            if (ParentId != comment.ParentId)
        res.Add(new LogChange("ParentId",this.ParentId, comment.ParentId));
            if (Message != comment.Message)
        res.Add(new LogChange("Message",this.Message, comment.Message));
            if (Approved != comment.Approved)
        res.Add(new LogChange("Approved",this.Approved, comment.Approved));

            return res;
        }
 }
}


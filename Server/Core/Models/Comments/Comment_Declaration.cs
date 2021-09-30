
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.Comments
{
    [TableName("Connect_ApiBrowser_Comments")]
    [PrimaryKey("CommentID", AutoIncrement = true)]
    [DataContract]
    public partial class Comment  : AuditableEntity 
    {

        #region .ctor
        public Comment()
        {
            CommentID = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int CommentID { get; set; }
        [DataMember]
        public int ComponentId { get; set; }
        [DataMember]
        public int ItemType { get; set; }
        [DataMember]
        public int ItemId { get; set; }
        [DataMember]
        public int? ParentId { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool? Approved { get; set; }
        #endregion

        #region Methods
        public void ReadComment(Comment comment)
        {
            if (comment.CommentID > -1)
                CommentID = comment.CommentID;

            if (comment.ComponentId > -1)
                ComponentId = comment.ComponentId;

            if (comment.ItemType > -1)
                ItemType = comment.ItemType;

            if (comment.ItemId > -1)
                ItemId = comment.ItemId;

            if (comment.ParentId > -1)
                ParentId = comment.ParentId;

            if (!String.IsNullOrEmpty(comment.Message))
                Message = comment.Message;

            if (comment.Approved != null)
            Approved = comment.Approved;

        }
        #endregion

    }
}




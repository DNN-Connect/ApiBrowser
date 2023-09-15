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
            CommentID = comment.CommentID;
            ComponentId = comment.ComponentId;
            ItemType = comment.ItemType;
            ItemId = comment.ItemId;
            ParentId = comment.ParentId;
            Message = comment.Message;
            Approved = comment.Approved;
        }
        #endregion

    }
}




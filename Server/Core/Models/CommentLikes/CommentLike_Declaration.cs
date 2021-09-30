
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.CommentLikes
{
    [TableName("Connect_ApiBrowser_CommentLikes")]
    [DataContract]
    public partial class CommentLike     {

        #region .ctor
        public CommentLike()
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public int CommentId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public DateTime Datime { get; set; }
        #endregion

        #region Methods
        public void ReadCommentLike(CommentLike commentLike)
        {
            if (commentLike.CommentId > -1)
                CommentId = commentLike.CommentId;

            if (commentLike.UserId > -1)
                UserId = commentLike.UserId;

            Datime = commentLike.Datime;

        }
        #endregion

    }
}




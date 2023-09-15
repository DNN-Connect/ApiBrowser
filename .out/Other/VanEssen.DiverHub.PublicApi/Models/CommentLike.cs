using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("Connect_ApiBrowser_CommentLikes")]
    public partial class CommentLike
    {

        public int CommentId { get; set; }
        public int UserId { get; set; }
        public DateTime Datime { get; set; }
    }
}

using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("Connect_ApiBrowser_Comments")]
    [PrimaryKey("CommentID", AutoIncrement = true)]
    public partial class Comment
    {

        public int CommentID { get; set; }
        public int ComponentId { get; set; }
        public int ItemType { get; set; }
        public int ItemId { get; set; }
        public int? ParentId { get; set; }
        public string Message { get; set; }
        public bool? Approved { get; set; }
    }
}

using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("Connect_ApiBrowser_ComponentHistories")]
    [PrimaryKey("ComponentHistoryId", AutoIncrement = true)]
    public partial class ComponentHistory
    {

        public int ComponentHistoryId { get; set; }
        public int ComponentId { get; set; }
        public string Version { get; set; }
        public string VersionNormalized { get; set; }
        public string FullName { get; set; }
        public int CodeLines { get; set; }
        public int? CommentLines { get; set; }
        public int? EmptyLines { get; set; }
    }
}

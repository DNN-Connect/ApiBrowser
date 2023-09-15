using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("Connect_ApiBrowser_MemberCodeBlocks")]
    [PrimaryKey("CodeBlockId", AutoIncrement = true)]
    public partial class MemberCodeBlock
    {

        public int CodeBlockId { get; set; }
        public int MemberId { get; set; }
        public string Version { get; set; }
        public string CodeHash { get; set; }
        public int? StartLine { get; set; }
        public int? StartColumn { get; set; }
        public int? EndLine { get; set; }
        public int? EndColumn { get; set; }
        public string FileName { get; set; }
    }
}

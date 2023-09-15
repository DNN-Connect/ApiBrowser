using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("vw_Connect_ApiBrowser_References")]
    [PrimaryKey("ReferenceId", AutoIncrement = true)]
    public partial class Reference
    {

        public int ReferenceId { get; set; }
        public int CodeBlockId { get; set; }
        public string FullName { get; set; }
        public int Offset { get; set; }
        public int? ReferencedMemberId { get; set; }
        public int FromRefMemberId { get; set; }
        public int? FromRefStartLine { get; set; }
        public int? FromRefEndLine { get; set; }
        public string FromRefMemberName { get; set; }
        public string FromRefFullName { get; set; }
        public string FromRefAppearedInVersion { get; set; }
        public string FromRefDeprecatedInVersion { get; set; }
        public string FromRefDisappearedInVersion { get; set; }
        public int FromRefClassId { get; set; }
        public string FromRefClassName { get; set; }
        public string FromRefFullQualifier { get; set; }
        public string ToRefMemberName { get; set; }
        public string ToRefFullName { get; set; }
        public string ToRefAppearedInVersion { get; set; }
        public string ToRefDeprecatedInVersion { get; set; }
        public string ToRefDisappearedInVersion { get; set; }
    }
}

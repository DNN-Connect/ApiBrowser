using System.Runtime.Serialization;

namespace Connect.ApiBrowser.Core.Models
{
   public class ModerationItem
    {
        [DataMember]
        public int DocType { get; set; }
        [DataMember]
        public int ClassId { get; set; }
        [DataMember]
        public int MemberId { get; set; }
        [DataMember]
        public int DocumentationId { get; set; }
        [DataMember]
        public string FullQualifier { get; set; }
        [DataMember]
        public string OldText { get; set; }
        [DataMember]
        public string NewText { get; set; }
        [DataMember]
        public System.DateTime LastModifiedOnDate { get; set; }
        [DataMember]
        public string LastModifiedByUserDisplayName { get; set; }
    }
}

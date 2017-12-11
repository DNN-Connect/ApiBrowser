using System.Runtime.Serialization;

namespace Connect.ApiBrowser.Core.Models
{
   public class CodeBlock
    {
        [IgnoreDataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public string Hash { get; set; }
    }
}

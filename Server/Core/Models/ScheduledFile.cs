using System.Runtime.Serialization;

namespace Connect.ApiBrowser.Core.Models
{
   public class ScheduledFile
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public long Size { get; set; }
        [DataMember]
        public bool Processing { get; set; }
    }
}

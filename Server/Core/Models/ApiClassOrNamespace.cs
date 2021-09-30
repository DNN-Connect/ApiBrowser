using System.Runtime.Serialization;

namespace Connect.ApiBrowser.Core.Models
{
    public class ApiClassOrNamespace
    {
        [DataMember]
        public int NamespaceId { get; set; }
        [DataMember]
        public int ClassId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public bool IsDeprecated { get; set; }
    }
}

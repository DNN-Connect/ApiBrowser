using System.Runtime.Serialization;

namespace Connect.ApiBrowser.Core.Models.Components
{
    public partial class ComponentWithStats: Component
    {
        [DataMember]
        public int NrClasses { get; set; }
        [DataMember]
        public int NrDocumentedClasses { get; set; }
        [DataMember]
        public int NrMembers { get; set; }
        [DataMember]
        public int NrDocumentedMembers { get; set; }
    }
}

using Connect.ApiBrowser.Core.Models.ApiClasses;
using Connect.ApiBrowser.Core.Models.ApiNamespaces;
using Connect.ApiBrowser.Core.Models.Members;

namespace Connect.ApiBrowser.Core.Models
{
    public class ViewSelection
    {
        public ApiNamespace SelectedNamespace { get; set; }
        public ApiClass SelectedClass { get; set; }
        public Member SelectedMember { get; set; }
    }
}

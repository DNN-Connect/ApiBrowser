using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("vw_Connect_ApiBrowser_NamespacesClassesAndMembers")]
    public partial class NamespacesClassesAndMember
    {

        public int ModuleId { get; set; }
        public int NamespaceId { get; set; }
        public int ClassId { get; set; }
        public int MemberId { get; set; }
        public int MainType { get; set; }
        public int SubType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PendingDescription { get; set; }
        public int IsDeprecated { get; set; }
        public string DeprecatedInVersion { get; set; }
        public string DisappearedInVersion { get; set; }
        public int? LastModifiedByUserID { get; set; }
        public DateTime? LastModifiedOnDate { get; set; }
    }
}

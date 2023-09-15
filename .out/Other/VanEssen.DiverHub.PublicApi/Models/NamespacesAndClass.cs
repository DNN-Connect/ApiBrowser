using System;
using PetaPoco;

namespace Connect.ApiBrowser.Core.PublicApi.Models
{

    [TableName("vw_Connect_ApiBrowser_NamespacesAndClasses")]
    public partial class NamespacesAndClass
    {

        public int ModuleId { get; set; }
        public int NamespaceId { get; set; }
        public int ClassId { get; set; }
        public bool? IsClass { get; set; }
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

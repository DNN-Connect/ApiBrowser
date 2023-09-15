using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.ApiBrowser.Core.Models.NamespacesClassesAndMembers
{

    [TableName("vw_Connect_ApiBrowser_NamespacesClassesAndMembers")]
    [DataContract]
    public partial class NamespacesClassesAndMember     {

        #region .ctor
        public NamespacesClassesAndMember()         {
        }
        #endregion

        #region Properties
        [DataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public int NamespaceId { get; set; }
        [DataMember]
        public int ClassId { get; set; }
        [DataMember]
        public int MemberId { get; set; }
        [DataMember]
        public int MainType { get; set; }
        [DataMember]
        public int SubType { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string PendingDescription { get; set; }
        [DataMember]
        public int IsDeprecated { get; set; }
        [DataMember]
        public string DeprecatedInVersion { get; set; }
        [DataMember]
        public string DisappearedInVersion { get; set; }
        [DataMember]
        public int? LastModifiedByUserID { get; set; }
        [DataMember]
        public DateTime? LastModifiedOnDate { get; set; }
        #endregion

        #region Methods
        public NamespacesClassesAndMember Clone()
        {
            NamespacesClassesAndMember res = new NamespacesClassesAndMember();
            return res;
        }
        #endregion

    }
}

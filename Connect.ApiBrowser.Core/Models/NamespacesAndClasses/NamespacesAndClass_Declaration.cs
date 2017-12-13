
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.ApiBrowser.Core.Models.NamespacesAndClasses
{

    [TableName("vw_Connect_ApiBrowser_NamespacesAndClasses")]
    [DataContract]
    public partial class NamespacesAndClass
    {

        #region .ctor
        public NamespacesAndClass()
        {
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
        public bool? IsClass { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int IsDeprecated { get; set; }
        [DataMember]
        public string DeprecatedInVersion { get; set; }
        [DataMember]
        public string DisappearedInVersion { get; set; }
        #endregion

        #region Methods
        public NamespacesAndClass Clone()
        {
            NamespacesAndClass res = new NamespacesAndClass();
            return res;
        }
        #endregion

    }
}

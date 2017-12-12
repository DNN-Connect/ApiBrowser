
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.ApiNamespaces
{
    [TableName("Connect_ApiBrowser_ApiNamespaces")]
    [PrimaryKey("NamespaceId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]
    public partial class ApiNamespace
    {

        #region .ctor
        public ApiNamespace()
        {
            NamespaceId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int NamespaceId { get; set; }
        [DataMember]
        public int ParentId { get; set; }
        [DataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public string NamespaceName { get; set; }
        [DataMember]
        public string LastQualifier { get; set; }
        [DataMember]
        public string Description { get; set; }
        #endregion

        #region Methods
        public void ReadApiNamespace(ApiNamespace apiNamespace)
        {
            if (apiNamespace.NamespaceId > -1)
                NamespaceId = apiNamespace.NamespaceId;

            if (apiNamespace.ParentId > -1)
                ParentId = apiNamespace.ParentId;

            if (apiNamespace.ModuleId > -1)
                ModuleId = apiNamespace.ModuleId;

            if (!String.IsNullOrEmpty(apiNamespace.NamespaceName))
                NamespaceName = apiNamespace.NamespaceName;

            if (!String.IsNullOrEmpty(apiNamespace.LastQualifier))
                LastQualifier = apiNamespace.LastQualifier;

            if (!String.IsNullOrEmpty(apiNamespace.Description))
                Description = apiNamespace.Description;

        }
        #endregion

    }
}




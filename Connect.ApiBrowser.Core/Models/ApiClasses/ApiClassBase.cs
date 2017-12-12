
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.ApiClasses
{
    [TableName("Connect_ApiBrowser_ApiClasses")]
    [PrimaryKey("ClassId", AutoIncrement = true)]
    [DataContract]
    public partial class ApiClassBase     {

        #region .ctor
        public ApiClassBase()
        {
            ClassId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int ClassId { get; set; }
        [DataMember]
        public int NamespaceId { get; set; }
        [DataMember]
        public int? ComponentId { get; set; }
        [DataMember]
        public string ClassName { get; set; }
        [DataMember]
        public string Declaration { get; set; }
        [DataMember]
        public string Documentation { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string AppearedInVersion { get; set; }
        [DataMember]
        public string DeprecatedInVersion { get; set; }
        [DataMember]
        public string DisappearedInVersion { get; set; }
        [DataMember]
        public bool IsDeprecated { get; set; }
        [DataMember]
        public string DeprecationMessage { get; set; }
        #endregion

        #region Methods
        public void ReadApiClassBase(ApiClassBase apiClass)
        {
            if (apiClass.ClassId > -1)
                ClassId = apiClass.ClassId;

            if (apiClass.NamespaceId > -1)
                NamespaceId = apiClass.NamespaceId;

            if (apiClass.ComponentId > -1)
                ComponentId = apiClass.ComponentId;

            if (!String.IsNullOrEmpty(apiClass.ClassName))
                ClassName = apiClass.ClassName;

            if (!String.IsNullOrEmpty(apiClass.Declaration))
                Declaration = apiClass.Declaration;

            if (!String.IsNullOrEmpty(apiClass.Documentation))
                Documentation = apiClass.Documentation;

            if (!String.IsNullOrEmpty(apiClass.Description))
                Description = apiClass.Description;

            if (!String.IsNullOrEmpty(apiClass.AppearedInVersion))
                AppearedInVersion = apiClass.AppearedInVersion;

            if (!String.IsNullOrEmpty(apiClass.DeprecatedInVersion))
                DeprecatedInVersion = apiClass.DeprecatedInVersion;

            if (!String.IsNullOrEmpty(apiClass.DisappearedInVersion))
                DisappearedInVersion = apiClass.DisappearedInVersion;

            IsDeprecated = apiClass.IsDeprecated;

            if (!String.IsNullOrEmpty(apiClass.DeprecationMessage))
                DeprecationMessage = apiClass.DeprecationMessage;

        }
        #endregion

    }
}




using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.ApiBrowser.Core.Models.ApiClasses
{

    [TableName("vw_Connect_ApiBrowser_ApiClasses")]
    [PrimaryKey("ClassId", AutoIncrement = true)]
    [DataContract]
    public partial class ApiClass  : ApiClassBase 
    {

        #region .ctor
        public ApiClass()  : base() 
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public string NamespaceName { get; set; }
        [DataMember]
        public string ComponentName { get; set; }
        [DataMember]
        public string LatestVersion { get; set; }
        [DataMember]
        public int? MemberCount { get; set; }
        #endregion

        #region Methods
        public ApiClassBase GetApiClassBase()
        {
            ApiClassBase res = new ApiClassBase();
             res.ClassId = ClassId;
             res.NamespaceId = NamespaceId;
             res.ComponentId = ComponentId;
             res.ClassName = ClassName;
             res.Declaration = Declaration;
             res.Documentation = Documentation;
             res.AppearedInVersion = AppearedInVersion;
             res.DeprecatedInVersion = DeprecatedInVersion;
             res.DisappearedInVersion = DisappearedInVersion;
             res.IsDeprecated = IsDeprecated;
             res.DeprecationMessage = DeprecationMessage;
            return res;
        }
        public ApiClass Clone()
        {
            ApiClass res = new ApiClass();
            res.ClassId = ClassId;
            res.NamespaceId = NamespaceId;
            res.ComponentId = ComponentId;
            res.ClassName = ClassName;
            res.Declaration = Declaration;
            res.Documentation = Documentation;
            res.AppearedInVersion = AppearedInVersion;
            res.DeprecatedInVersion = DeprecatedInVersion;
            res.DisappearedInVersion = DisappearedInVersion;
            res.IsDeprecated = IsDeprecated;
            res.DeprecationMessage = DeprecationMessage;
            res.NamespaceName = NamespaceName;
            res.ComponentName = ComponentName;
            res.LatestVersion = LatestVersion;
            res.MemberCount = MemberCount;
            return res;
        }
        #endregion

    }
}

using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Connect.ApiBrowser.Core.Models.Documentations
{

    [TableName("vw_Connect_ApiBrowser_Documentations")]
    [PrimaryKey("DocumentationId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]                
    public partial class Documentation  : DocumentationBase 
    {

        #region .ctor
        public Documentation()  : base() 
        {
        }
        #endregion

        #region Properties
        [DataMember]
        public bool? IsCurrentVersion { get; set; }
        [DataMember]
        public string CreatedByUserDisplayName { get; set; }
        [DataMember]
        public string CreatedByUserEmail { get; set; }
        [DataMember]
        public string LastModifiedByUserDisplayName { get; set; }
        [DataMember]
        public string LastModifiedByUserEmail { get; set; }
        #endregion

        #region Methods
        public DocumentationBase GetDocumentationBase()
        {
            DocumentationBase res = new DocumentationBase();
             res.DocumentationId = DocumentationId;
             res.ModuleId = ModuleId;
             res.FullName = FullName;
             res.Contents = Contents;
            res.CreatedByUserID = CreatedByUserID;
            res.CreatedOnDate = CreatedOnDate;
            res.LastModifiedByUserID = LastModifiedByUserID;
            res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        public Documentation Clone()
        {
            Documentation res = new Documentation();
            res.DocumentationId = DocumentationId;
            res.ModuleId = ModuleId;
            res.FullName = FullName;
            res.Contents = Contents;
            res.IsCurrentVersion = IsCurrentVersion;
            res.CreatedByUserDisplayName = CreatedByUserDisplayName;
            res.CreatedByUserEmail = CreatedByUserEmail;
            res.LastModifiedByUserDisplayName = LastModifiedByUserDisplayName;
            res.LastModifiedByUserEmail = LastModifiedByUserEmail;
            res.CreatedByUserID = CreatedByUserID;
            res.CreatedOnDate = CreatedOnDate;
            res.LastModifiedByUserID = LastModifiedByUserID;
            res.LastModifiedOnDate = LastModifiedOnDate;
            return res;
        }
        #endregion

    }
}

using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.Documentations
{
    [TableName("Connect_ApiBrowser_Documentations")]
    [PrimaryKey("DocumentationId", AutoIncrement = true)]
    [DataContract]
    [Scope("ModuleId")]
    public partial class DocumentationBase  : AuditableEntity 
    {

        #region .ctor
        public DocumentationBase()
        {
            DocumentationId = -1;
        }
        #endregion

        #region Properties
        [DataMember]
        public int DocumentationId { get; set; }
        [DataMember]
        public int ModuleId { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Contents { get; set; }
        #endregion

        #region Methods
        public void ReadDocumentationBase(DocumentationBase documentation)
        {
            DocumentationId = documentation.DocumentationId;
            ModuleId = documentation.ModuleId;
            FullName = documentation.FullName;
            Contents = documentation.Contents;
        }
        #endregion

    }
}




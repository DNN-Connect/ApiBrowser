
using System;
using System.Runtime.Serialization;
using DotNetNuke.ComponentModel.DataAnnotations;
using Connect.ApiBrowser.Core.Data;

namespace Connect.ApiBrowser.Core.Models.Documentations
{
    [TableName("Connect_ApiBrowser_Documentations")]
    [PrimaryKey("DocumentationId", AutoIncrement = true)]
    [DataContract]
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
        public int ClassId { get; set; }
        [DataMember]
        public int MemberId { get; set; }
        [DataMember]
        public string Contents { get; set; }
        #endregion

        #region Methods
        public void ReadDocumentationBase(DocumentationBase documentation)
        {
            if (documentation.DocumentationId > -1)
                DocumentationId = documentation.DocumentationId;

            if (documentation.ClassId > -1)
                ClassId = documentation.ClassId;

            if (documentation.MemberId > -1)
                MemberId = documentation.MemberId;

            if (!String.IsNullOrEmpty(documentation.Contents))
                Contents = documentation.Contents;

        }
        #endregion

    }
}




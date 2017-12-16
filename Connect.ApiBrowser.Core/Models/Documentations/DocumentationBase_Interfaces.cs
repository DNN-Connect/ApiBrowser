
using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.Documentations
{
    public partial class DocumentationBase : IHydratable, IPropertyAccess
    {

        #region IHydratable

        public virtual void Fill(IDataReader dr)
        {
            FillAuditFields(dr);
   DocumentationId = Convert.ToInt32(Null.SetNull(dr["DocumentationId"], DocumentationId));
   ClassId = Convert.ToInt32(Null.SetNull(dr["ClassId"], ClassId));
   MemberId = Convert.ToInt32(Null.SetNull(dr["MemberId"], MemberId));
   Contents = Convert.ToString(Null.SetNull(dr["Contents"], Contents));
        }

        [IgnoreColumn()]
        public int KeyID
        {
            get { return DocumentationId; }
            set { DocumentationId = value; }
        }
        #endregion

        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "documentationid": // Int
     return DocumentationId.ToString(strFormat, formatProvider);
    case "classid": // Int
     return ClassId.ToString(strFormat, formatProvider);
    case "memberid": // Int
     return MemberId.ToString(strFormat, formatProvider);
    case "contents": // NVarCharMax
     return PropertyAccess.FormatString(Contents, strFormat);
                default:
                    propertyNotFound = true;
                    break;
            }

            return Null.NullString;
        }

        [IgnoreColumn()]
        public CacheLevel Cacheability
        {
            get { return CacheLevel.fullyCacheable; }
        }
        #endregion

    }
}



using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.References
{
    public partial class ReferenceBase : IHydratable, IPropertyAccess
    {

        #region IHydratable

        public virtual void Fill(IDataReader dr)
        {
   ReferenceId = Convert.ToInt32(Null.SetNull(dr["ReferenceId"], ReferenceId));
   CodeBlockId = Convert.ToInt32(Null.SetNull(dr["CodeBlockId"], CodeBlockId));
   FullName = Convert.ToString(Null.SetNull(dr["FullName"], FullName));
   Offset = Convert.ToInt32(Null.SetNull(dr["Offset"], Offset));
   ReferencedMemberId = Convert.ToInt32(Null.SetNull(dr["ReferencedMemberId"], ReferencedMemberId));
        }

        [IgnoreColumn()]
        public int KeyID
        {
            get { return ReferenceId; }
            set { ReferenceId = value; }
        }
        #endregion

        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "referenceid": // Int
     return ReferenceId.ToString(strFormat, formatProvider);
    case "codeblockid": // Int
     return CodeBlockId.ToString(strFormat, formatProvider);
    case "fullname": // VarChar
     return PropertyAccess.FormatString(FullName, strFormat);
    case "offset": // Int
     return Offset.ToString(strFormat, formatProvider);
    case "referencedmemberid": // Int
     if (ReferencedMemberId == null)
     {
         return "";
     };
     return ((int)ReferencedMemberId).ToString(strFormat, formatProvider);
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


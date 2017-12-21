
using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.Members
{
    public partial class MemberBase : IHydratable, IPropertyAccess
    {

        #region IHydratable

        public virtual void Fill(IDataReader dr)
        {
            FillAuditFields(dr);
   MemberId = Convert.ToInt32(Null.SetNull(dr["MemberId"], MemberId));
   ClassId = Convert.ToInt32(Null.SetNull(dr["ClassId"], ClassId));
   MemberType = Convert.ToInt32(Null.SetNull(dr["MemberType"], MemberType));
   MemberName = Convert.ToString(Null.SetNull(dr["MemberName"], MemberName));
   Declaration = Convert.ToString(Null.SetNull(dr["Declaration"], Declaration));
   Documentation = Convert.ToString(Null.SetNull(dr["Documentation"], Documentation));
   Description = Convert.ToString(Null.SetNull(dr["Description"], Description));
   AppearedInVersion = Convert.ToString(Null.SetNull(dr["AppearedInVersion"], AppearedInVersion));
   DeprecatedInVersion = Convert.ToString(Null.SetNull(dr["DeprecatedInVersion"], DeprecatedInVersion));
   DisappearedInVersion = Convert.ToString(Null.SetNull(dr["DisappearedInVersion"], DisappearedInVersion));
   IsDeprecated = Convert.ToBoolean(Null.SetNull(dr["IsDeprecated"], IsDeprecated));
   DeprecationMessage = Convert.ToString(Null.SetNull(dr["DeprecationMessage"], DeprecationMessage));
   DocumentationId = Convert.ToInt32(Null.SetNull(dr["DocumentationId"], DocumentationId));
   PendingDescription = Convert.ToString(Null.SetNull(dr["PendingDescription"], PendingDescription));
        }

        [IgnoreColumn()]
        public int KeyID
        {
            get { return MemberId; }
            set { MemberId = value; }
        }
        #endregion

        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "memberid": // Int
     return MemberId.ToString(strFormat, formatProvider);
    case "classid": // Int
     return ClassId.ToString(strFormat, formatProvider);
    case "membertype": // Int
     return MemberType.ToString(strFormat, formatProvider);
    case "membername": // NVarChar
     return PropertyAccess.FormatString(MemberName, strFormat);
    case "declaration": // NVarChar
     if (Declaration == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Declaration, strFormat);
    case "documentation": // NVarCharMax
     if (Documentation == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Documentation, strFormat);
    case "description": // NVarCharMax
     if (Description == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(Description, strFormat);
    case "appearedinversion": // VarChar
     return PropertyAccess.FormatString(AppearedInVersion, strFormat);
    case "deprecatedinversion": // VarChar
     if (DeprecatedInVersion == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(DeprecatedInVersion, strFormat);
    case "disappearedinversion": // VarChar
     if (DisappearedInVersion == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(DisappearedInVersion, strFormat);
    case "isdeprecated": // Bit
     return IsDeprecated.ToString();
    case "deprecationmessage": // NVarChar
     if (DeprecationMessage == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(DeprecationMessage, strFormat);
    case "documentationid": // Int
     if (DocumentationId == null)
     {
         return "";
     };
     return ((int)DocumentationId).ToString(strFormat, formatProvider);
    case "pendingdescription": // NVarCharMax
     if (PendingDescription == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(PendingDescription, strFormat);
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


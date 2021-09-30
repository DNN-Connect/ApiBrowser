
using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.ApiBrowser.Core.Models.MemberCodeBlocks
{
    public partial class MemberCodeBlock : IHydratable, IPropertyAccess
    {

        #region IHydratable

        public virtual void Fill(IDataReader dr)
        {
   CodeBlockId = Convert.ToInt32(Null.SetNull(dr["CodeBlockId"], CodeBlockId));
   MemberId = Convert.ToInt32(Null.SetNull(dr["MemberId"], MemberId));
   Version = Convert.ToString(Null.SetNull(dr["Version"], Version));
   CodeHash = Convert.ToString(Null.SetNull(dr["CodeHash"], CodeHash));
   StartLine = Convert.ToInt32(Null.SetNull(dr["StartLine"], StartLine));
   StartColumn = Convert.ToInt32(Null.SetNull(dr["StartColumn"], StartColumn));
   EndLine = Convert.ToInt32(Null.SetNull(dr["EndLine"], EndLine));
   EndColumn = Convert.ToInt32(Null.SetNull(dr["EndColumn"], EndColumn));
   FileName = Convert.ToString(Null.SetNull(dr["FileName"], FileName));
        }

        [IgnoreColumn()]
        public int KeyID
        {
            get { return CodeBlockId; }
            set { CodeBlockId = value; }
        }
        #endregion

        #region IPropertyAccess
        public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
        {
            switch (strPropertyName.ToLower())
            {
    case "codeblockid": // Int
     return CodeBlockId.ToString(strFormat, formatProvider);
    case "memberid": // Int
     return MemberId.ToString(strFormat, formatProvider);
    case "version": // VarChar
     return PropertyAccess.FormatString(Version, strFormat);
    case "codehash": // Char
     return PropertyAccess.FormatString(CodeHash, strFormat);
    case "startline": // Int
     if (StartLine == null)
     {
         return "";
     };
     return ((int)StartLine).ToString(strFormat, formatProvider);
    case "startcolumn": // Int
     if (StartColumn == null)
     {
         return "";
     };
     return ((int)StartColumn).ToString(strFormat, formatProvider);
    case "endline": // Int
     if (EndLine == null)
     {
         return "";
     };
     return ((int)EndLine).ToString(strFormat, formatProvider);
    case "endcolumn": // Int
     if (EndColumn == null)
     {
         return "";
     };
     return ((int)EndColumn).ToString(strFormat, formatProvider);
    case "filename": // NVarChar
     if (FileName == null)
     {
         return "";
     };
     return PropertyAccess.FormatString(FileName, strFormat);
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


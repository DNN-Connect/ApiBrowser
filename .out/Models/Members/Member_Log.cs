using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.Members
{
    public partial class MemberBase
 {
        public List<LogChange> CompareWith(MemberBase member)
        {
      var res = new List<LogChange>();
            if (MemberId != member.MemberId)
        res.Add(new LogChange("MemberId",this.MemberId, member.MemberId));
            if (ClassId != member.ClassId)
        res.Add(new LogChange("ClassId",this.ClassId, member.ClassId));
            if (MemberType != member.MemberType)
        res.Add(new LogChange("MemberType",this.MemberType, member.MemberType));
            if (MemberName != member.MemberName)
        res.Add(new LogChange("MemberName",this.MemberName, member.MemberName));
            if (Declaration != member.Declaration)
        res.Add(new LogChange("Declaration",this.Declaration, member.Declaration));
            if (Documentation != member.Documentation)
        res.Add(new LogChange("Documentation",this.Documentation, member.Documentation));
            if (Description != member.Description)
        res.Add(new LogChange("Description",this.Description, member.Description));
            if (AppearedInVersion != member.AppearedInVersion)
        res.Add(new LogChange("AppearedInVersion",this.AppearedInVersion, member.AppearedInVersion));
            if (DeprecatedInVersion != member.DeprecatedInVersion)
        res.Add(new LogChange("DeprecatedInVersion",this.DeprecatedInVersion, member.DeprecatedInVersion));
            if (DisappearedInVersion != member.DisappearedInVersion)
        res.Add(new LogChange("DisappearedInVersion",this.DisappearedInVersion, member.DisappearedInVersion));
            if (IsDeprecated != member.IsDeprecated)
        res.Add(new LogChange("IsDeprecated",this.IsDeprecated, member.IsDeprecated));
            if (DeprecationMessage != member.DeprecationMessage)
        res.Add(new LogChange("DeprecationMessage",this.DeprecationMessage, member.DeprecationMessage));
            if (DocumentationId != member.DocumentationId)
        res.Add(new LogChange("DocumentationId",this.DocumentationId, member.DocumentationId));
            if (PendingDescription != member.PendingDescription)
        res.Add(new LogChange("PendingDescription",this.PendingDescription, member.PendingDescription));
            if (FullName != member.FullName)
        res.Add(new LogChange("FullName",this.FullName, member.FullName));
            if (IsAbstract != member.IsAbstract)
        res.Add(new LogChange("IsAbstract",this.IsAbstract, member.IsAbstract));
            if (IsPrivate != member.IsPrivate)
        res.Add(new LogChange("IsPrivate",this.IsPrivate, member.IsPrivate));
            if (IsStatic != member.IsStatic)
        res.Add(new LogChange("IsStatic",this.IsStatic, member.IsStatic));
            if (IsGetter != member.IsGetter)
        res.Add(new LogChange("IsGetter",this.IsGetter, member.IsGetter));
            if (IsSetter != member.IsSetter)
        res.Add(new LogChange("IsSetter",this.IsSetter, member.IsSetter));

            return res;
        }
 }
}


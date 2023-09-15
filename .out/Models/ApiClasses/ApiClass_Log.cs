using System;
using System.Collections.Generic;
using Connect.ApiBrowser.Core.Core.Services.Logging;

namespace Connect.ApiBrowser.Core.Models.ApiClasses
{
    public partial class ApiClassBase
 {
        public List<LogChange> CompareWith(ApiClassBase apiClass)
        {
      var res = new List<LogChange>();
            if (ClassId != apiClass.ClassId)
        res.Add(new LogChange("ClassId",this.ClassId, apiClass.ClassId));
            if (NamespaceId != apiClass.NamespaceId)
        res.Add(new LogChange("NamespaceId",this.NamespaceId, apiClass.NamespaceId));
            if (ComponentId != apiClass.ComponentId)
        res.Add(new LogChange("ComponentId",this.ComponentId, apiClass.ComponentId));
            if (ClassName != apiClass.ClassName)
        res.Add(new LogChange("ClassName",this.ClassName, apiClass.ClassName));
            if (Declaration != apiClass.Declaration)
        res.Add(new LogChange("Declaration",this.Declaration, apiClass.Declaration));
            if (Documentation != apiClass.Documentation)
        res.Add(new LogChange("Documentation",this.Documentation, apiClass.Documentation));
            if (Description != apiClass.Description)
        res.Add(new LogChange("Description",this.Description, apiClass.Description));
            if (AppearedInVersion != apiClass.AppearedInVersion)
        res.Add(new LogChange("AppearedInVersion",this.AppearedInVersion, apiClass.AppearedInVersion));
            if (DeprecatedInVersion != apiClass.DeprecatedInVersion)
        res.Add(new LogChange("DeprecatedInVersion",this.DeprecatedInVersion, apiClass.DeprecatedInVersion));
            if (DisappearedInVersion != apiClass.DisappearedInVersion)
        res.Add(new LogChange("DisappearedInVersion",this.DisappearedInVersion, apiClass.DisappearedInVersion));
            if (IsDeprecated != apiClass.IsDeprecated)
        res.Add(new LogChange("IsDeprecated",this.IsDeprecated, apiClass.IsDeprecated));
            if (DeprecationMessage != apiClass.DeprecationMessage)
        res.Add(new LogChange("DeprecationMessage",this.DeprecationMessage, apiClass.DeprecationMessage));
            if (DocumentationId != apiClass.DocumentationId)
        res.Add(new LogChange("DocumentationId",this.DocumentationId, apiClass.DocumentationId));
            if (PendingDescription != apiClass.PendingDescription)
        res.Add(new LogChange("PendingDescription",this.PendingDescription, apiClass.PendingDescription));
            if (FullName != apiClass.FullName)
        res.Add(new LogChange("FullName",this.FullName, apiClass.FullName));
            if (IsAbstract != apiClass.IsAbstract)
        res.Add(new LogChange("IsAbstract",this.IsAbstract, apiClass.IsAbstract));
            if (IsAnsiClass != apiClass.IsAnsiClass)
        res.Add(new LogChange("IsAnsiClass",this.IsAnsiClass, apiClass.IsAnsiClass));
            if (IsArray != apiClass.IsArray)
        res.Add(new LogChange("IsArray",this.IsArray, apiClass.IsArray));
            if (IsAutoClass != apiClass.IsAutoClass)
        res.Add(new LogChange("IsAutoClass",this.IsAutoClass, apiClass.IsAutoClass));
            if (IsAutoLayout != apiClass.IsAutoLayout)
        res.Add(new LogChange("IsAutoLayout",this.IsAutoLayout, apiClass.IsAutoLayout));
            if (IsBeforeFieldInit != apiClass.IsBeforeFieldInit)
        res.Add(new LogChange("IsBeforeFieldInit",this.IsBeforeFieldInit, apiClass.IsBeforeFieldInit));
            if (IsByReference != apiClass.IsByReference)
        res.Add(new LogChange("IsByReference",this.IsByReference, apiClass.IsByReference));
            if (IsClass != apiClass.IsClass)
        res.Add(new LogChange("IsClass",this.IsClass, apiClass.IsClass));
            if (IsDefinition != apiClass.IsDefinition)
        res.Add(new LogChange("IsDefinition",this.IsDefinition, apiClass.IsDefinition));
            if (IsEnum != apiClass.IsEnum)
        res.Add(new LogChange("IsEnum",this.IsEnum, apiClass.IsEnum));
            if (IsExplicitLayout != apiClass.IsExplicitLayout)
        res.Add(new LogChange("IsExplicitLayout",this.IsExplicitLayout, apiClass.IsExplicitLayout));
            if (IsFunctionPointer != apiClass.IsFunctionPointer)
        res.Add(new LogChange("IsFunctionPointer",this.IsFunctionPointer, apiClass.IsFunctionPointer));
            if (IsGenericInstance != apiClass.IsGenericInstance)
        res.Add(new LogChange("IsGenericInstance",this.IsGenericInstance, apiClass.IsGenericInstance));
            if (IsGenericParameter != apiClass.IsGenericParameter)
        res.Add(new LogChange("IsGenericParameter",this.IsGenericParameter, apiClass.IsGenericParameter));
            if (IsImport != apiClass.IsImport)
        res.Add(new LogChange("IsImport",this.IsImport, apiClass.IsImport));
            if (IsInterface != apiClass.IsInterface)
        res.Add(new LogChange("IsInterface",this.IsInterface, apiClass.IsInterface));
            if (IsNested != apiClass.IsNested)
        res.Add(new LogChange("IsNested",this.IsNested, apiClass.IsNested));
            if (IsNestedAssembly != apiClass.IsNestedAssembly)
        res.Add(new LogChange("IsNestedAssembly",this.IsNestedAssembly, apiClass.IsNestedAssembly));
            if (IsNestedPrivate != apiClass.IsNestedPrivate)
        res.Add(new LogChange("IsNestedPrivate",this.IsNestedPrivate, apiClass.IsNestedPrivate));
            if (IsNestedPublic != apiClass.IsNestedPublic)
        res.Add(new LogChange("IsNestedPublic",this.IsNestedPublic, apiClass.IsNestedPublic));
            if (IsNotPublic != apiClass.IsNotPublic)
        res.Add(new LogChange("IsNotPublic",this.IsNotPublic, apiClass.IsNotPublic));
            if (ParentClassId != apiClass.ParentClassId)
        res.Add(new LogChange("ParentClassId",this.ParentClassId, apiClass.ParentClassId));

            return res;
        }
 }
}


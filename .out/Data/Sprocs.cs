using System;
using System.Collections.Generic;
using DotNetNuke.Data;

namespace Connect.ApiBrowser.Core.Data
{
    public class Sprocs
    {
        // UPDATE dbo.Connect_ApiBrowser_ApiClasses
        //  SET [DisappearedInVersion]=@Version
        //  WHERE [ClassId]=@ClassId
        //   AND ISNULL([DisappearedInVersion],'99.99.99') > @Version;  
        public static void ClassDisappeared(int ClassId, string Version)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_ClassDisappeared",
                    ClassId, Version);
            }
        }

        // SELECT
        //  c.*,
        //  (SELECT COUNT(*) FROM dbo.Connect_ApiBrowser_ApiClasses cl WHERE cl.ComponentId=c.ComponentId) NrClasses,
        //  (SELECT COUNT(*) FROM dbo.Connect_ApiBrowser_ApiClasses cl WHERE cl.ComponentId=c.ComponentId AND ISNULL(cl.DocumentationId, -1) <> -1) NrDocumentedClasses,
        //  (SELECT COUNT(*) FROM dbo.Connect_ApiBrowser_Members m INNER JOIN dbo.Connect_ApiBrowser_ApiClasses cl ON m.ClassId=cl.ClassId WHERE cl.ComponentId=c.ComponentId) NrMembers,
        //  (SELECT COUNT(*) FROM dbo.Connect_ApiBrowser_Members m INNER JOIN dbo.Connect_ApiBrowser_ApiClasses cl ON m.ClassId=cl.ClassId WHERE cl.ComponentId=c.ComponentId AND ISNULL(m.DocumentationId, -1) <> -1) NrDocumentedMembers
        // FROM dbo.Connect_ApiBrowser_Components c
        // WHERE c.ModuleId=@ModuleId;  
        public static IEnumerable<Component> GetComponents(int ModuleId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<Component>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetComponents",
                    ModuleId);
            }
        }

        // SELECT
        // *
        // FROM (SELECT
        //  0 DocType,
        //  c.ClassId,
        //  -1 MemberId,
        //  -1 DocumentationId,
        //  c.FullQualifier,
        //  c.Description OldText,
        //  c.PendingDescription NewText,
        //  c.LastModifiedOnDate,
        //  c.LastModifiedByUserDisplayName
        // FROM dbo.vw_Connect_ApiBrowser_ApiClasses c
        // WHERE NOT c.PendingDescription IS NULL AND c.ModuleId=@ModuleId
        // UNION
        // SELECT
        //  1 DocType,
        //  m.ClassId,
        //  m.MemberId,
        //  -1 DocumentationId,
        //  m.FullQualifier,
        //  m.Description OldText,
        //  m.PendingDescription NewText,
        //  m.LastModifiedOnDate,
        //  m.LastModifiedByUserDisplayName
        // FROM dbo.vw_Connect_ApiBrowser_Members m
        // WHERE NOT m.PendingDescription IS NULL AND m.ModuleId=@ModuleId
        // UNION
        // SELECT
        //  2 DocType,
        //  -1 ClassId,
        //  -1 MemberId,
        //  d1.DocumentationId,
        //  d1.FullName FullQualifier,
        //  d2.Contents OldText,
        //  d1.Contents NewText,
        //  d1.LastModifiedOnDate,
        //  d1.LastModifiedByUserDisplayName
        // FROM dbo.vw_Connect_ApiBrowser_Documentations d1
        //  LEFT JOIN dbo.vw_Connect_ApiBrowser_Documentations d2 ON d1.FullName=d2.FullName AND d2.IsCurrentVersion=1 AND d2.ModuleId=@ModuleId
        // WHERE d1.ModuleId=@ModuleId AND d1.LastModifiedOnDate > d2.LastModifiedOnDate OR d2.DocumentationId IS NULL) x
        // ORDER BY x.FullQualifier, x.LastModifiedOnDate;  
        public static IEnumerable<object> GetModerationList(int ModuleId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<object>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetModerationList",
                    ModuleId);
            }
        }

        // SELECT
        // *
        // FROM (SELECT 
        //  a.NamespaceId, 
        //  a.ClassId,
        //  n.NamespaceName + '.' + a.ClassName [Name],
        //  a.Description,
        //  a.IsDeprecated
        // FROM dbo.Connect_ApiBrowser_ApiClasses a
        // INNER JOIN dbo.Connect_ApiBrowser_ApiNamespaces n ON n.NamespaceId=a.NamespaceId
        // WHERE n.ModuleId=@ModuleId
        // UNION
        // SELECT
        //  n.NamespaceId,
        //  -1 ClassId,
        //  n.NamespaceName [Name],
        //  n.Description,
        //  0 IsDeprecated
        // FROM dbo.Connect_ApiBrowser_ApiNamespaces n
        // WHERE n.ModuleId=@ModuleId) x
        // ORDER BY x.[Name];  
        public static IEnumerable<object> GetNamespacesAndClasses(int ModuleId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<object>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetNamespacesAndClasses",
                    ModuleId);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_ApiClasses WHERE [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ParentClassId]=@ParentClassId AND [ClassName]=@ClassName)
        //  INSERT INTO dbo.Connect_ApiBrowser_ApiClasses ([NamespaceId], [ComponentId], [ParentClassId], [ClassName], [FullName], [Declaration], [Documentation], [Description],[AppearedInVersion], [DeprecatedInVersion], [DisappearedInVersion], [IsDeprecated], [DeprecationMessage], [CreatedByUserID], [CreatedOnDate], [LastModifiedByUserID], [LastModifiedOnDate], [IsAbstract],[IsAnsiClass],[IsArray],[IsAutoClass],[IsAutoLayout],[IsBeforeFieldInit],[IsByReference],[IsClass],[IsDefinition],[IsEnum],[IsExplicitLayout],[IsFunctionPointer],[IsGenericInstance],[IsGenericParameter],[IsImport],[IsInterface],[IsNested],[IsNestedAssembly],[IsNestedPrivate],[IsNestedPublic],[IsNotPublic])
        //   VALUES (@NamespaceId, @ComponentId, @ParentClassId, @ClassName, @FullName, @Declaration, @Documentation, @Description, @Version, NULL, NULL, 0, NULL, -1, GETDATE(), -1, GETDATE(), @IsAbstract, @IsAnsiClass, @IsArray, @IsAutoClass, @IsAutoLayout, @IsBeforeFieldInit, @IsByReference, @IsClass, @IsDefinition, @IsEnum, @IsExplicitLayout, @IsFunctionPointer, @IsGenericInstance, @IsGenericParameter, @IsImport, @IsInterface, @IsNested, @IsNestedAssembly, @IsNestedPrivate, @IsNestedPublic, @IsNotPublic);
        // UPDATE dbo.Connect_ApiBrowser_ApiClasses
        //  SET [AppearedInVersion]=@Version, [FullName]=@FullName
        //  WHERE [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ParentClassId]=@ParentClassId AND [ClassName]=@ClassName AND [AppearedInVersion]>@Version;
        // IF @IsDeprecated=1
        // BEGIN
        //  IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_ApiClasses WHERE [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ClassName]=@ClassName
        //   AND ISNULL([DeprecatedInVersion],'99.99.99') < @Version)
        //  UPDATE dbo.Connect_ApiBrowser_ApiClasses
        //   SET [DeprecatedInVersion]=@Version,
        //    [IsDeprecated]=1,
        //    [DeprecationMessage]=ISNULL([DeprecationMessage], @DeprecationMessage)
        //   WHERE [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ParentClassId]=@ParentClassId AND [ClassName]=@ClassName;
        // END;
        // UPDATE dbo.Connect_ApiBrowser_ApiClasses
        //  SET [Declaration]=ISNULL([Declaration],@Declaration),
        //   [Documentation]=ISNULL([Documentation],@Documentation)
        //  WHERE
        //   [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ParentClassId]=@ParentClassId AND [ClassName]=@ClassName;
        // SELECT
        //  *
        // FROM dbo.Connect_ApiBrowser_ApiClasses
        // WHERE
        //  [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ParentClassId]=@ParentClassId AND [ClassName]=@ClassName;;;  
        public static IEnumerable<object> GetOrCreateClass(int NamespaceId, int ComponentId, int ParentClassId, string ClassName, string FullName, string Declaration, string Documentation, string Description, string Version, bool IsDeprecated, string DeprecationMessage, bool IsAbstract, bool IsAnsiClass, bool IsArray, bool IsAutoClass, bool IsAutoLayout, bool IsBeforeFieldInit, bool IsByReference, bool IsClass, bool IsDefinition, bool IsEnum, bool IsExplicitLayout, bool IsFunctionPointer, bool IsGenericInstance, bool IsGenericParameter, bool IsImport, bool IsInterface, bool IsNested, bool IsNestedAssembly, bool IsNestedPrivate, bool IsNestedPublic, bool IsNotPublic)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<object>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateClass",
                    NamespaceId, ComponentId, ParentClassId, ClassName, FullName, Declaration, Documentation, Description, Version, IsDeprecated, DeprecationMessage, IsAbstract, IsAnsiClass, IsArray, IsAutoClass, IsAutoLayout, IsBeforeFieldInit, IsByReference, IsClass, IsDefinition, IsEnum, IsExplicitLayout, IsFunctionPointer, IsGenericInstance, IsGenericParameter, IsImport, IsInterface, IsNested, IsNestedAssembly, IsNestedPrivate, IsNestedPublic, IsNotPublic);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_Components WHERE [ModuleId]=@ModuleId AND [ComponentName]=@ComponentName)
        //  INSERT INTO dbo.Connect_ApiBrowser_Components ([ModuleId], [ComponentName], [LatestVersion])
        //   VALUES (@ModuleId, @ComponentName, @LatestVersion);
        // ELSE
        //  UPDATE dbo.Connect_ApiBrowser_Components
        //   SET [LatestVersion]=@LatestVersion
        //   WHERE [ModuleId]=@ModuleId
        //    AND [ComponentName]=@ComponentName
        //    AND [LatestVersion]<@LatestVersion;
        // SELECT *
        //  FROM dbo.Connect_ApiBrowser_Components
        //  WHERE [ModuleId]=@ModuleId
        //    AND [ComponentName]=@ComponentName;;  
        public static IEnumerable<object> GetOrCreateComponent(int ModuleId, string ComponentName, string LatestVersion)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<object>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateComponent",
                    ModuleId, ComponentName, LatestVersion);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_ComponentHistories WHERE [ComponentId]=@ComponentId AND [Version]=@Version)
        //  INSERT INTO dbo.Connect_ApiBrowser_ComponentHistories ([ComponentId],[Version],[VersionNormalized],[FullName],[CodeLines],[CommentLines],[EmptyLines])
        //   VALUES (@ComponentId, @Version, @VersionNormalized, @FullName, @CodeLines, @CommentLines, @EmptyLines);
        // ELSE
        //  UPDATE dbo.Connect_ApiBrowser_ComponentHistories
        //   SET [FullName]=@FullName,
        //   [CodeLines]=@CodeLines,
        //   [CommentLines]=@CommentLines,
        //   [EmptyLines]=@EmptyLines
        //   WHERE [ComponentId]=@ComponentId AND [Version]=@Version;
        // SELECT *
        //  FROM dbo.Connect_ApiBrowser_ComponentHistories 
        //  WHERE [ComponentId]=@ComponentId AND [Version]=@Version;;  
        public static IEnumerable<object> GetOrCreateComponentHistory(int ComponentId, string FullName, string Version, string VersionNormalized, int CodeLines, int CommentLines, int EmptyLines)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<object>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateComponentHistory",
                    ComponentId, FullName, Version, VersionNormalized, CodeLines, CommentLines, EmptyLines);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_Dependencies WHERE [ComponentHistoryId]=@ComponentHistoryId AND [FullName]=@FullName)
        // INSERT INTO dbo.Connect_ApiBrowser_Dependencies
        // ([ComponentHistoryId],[FullName],[Version],[VersionNormalized],[Name])
        // VALUES (@ComponentHistoryId, @FullName, @Version, @VersionNormalized, @Name)
        // ELSE
        // UPDATE dbo.Connect_ApiBrowser_Dependencies
        // SET [Version]=@Version, [VersionNormalized]=@VersionNormalized, [Name]=@Name
        // WHERE [ComponentHistoryId]=@ComponentHistoryId AND [FullName]=@FullName
        // SELECT * FROM dbo.vw_Connect_ApiBrowser_Dependencies
        // WHERE [ComponentHistoryId]=@ComponentHistoryId AND [FullName]=@FullName;  
        public static IEnumerable<object> GetOrCreateDependency(int ComponentHistoryId, string FullName, string Version, string VersionNormalized, string Name)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<object>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateDependency",
                    ComponentHistoryId, FullName, Version, VersionNormalized, Name);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_Members WHERE [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName AND [IsAbstract]=@IsAbstract AND [IsPrivate]=@IsPrivate AND [IsStatic]=@IsStatic AND [IsGetter]=@IsGetter AND [IsSetter]=@IsSetter)
        //  INSERT INTO dbo.Connect_ApiBrowser_Members ([ClassId],[MemberType],[MemberName],[FullName],[Declaration],[Documentation],[Description], [AppearedInVersion],[DeprecatedInVersion],[DisappearedInVersion],[IsDeprecated],[DeprecationMessage], [CreatedByUserID], [CreatedOnDate], [LastModifiedByUserID], [LastModifiedOnDate], [IsAbstract], [IsPrivate], [IsStatic], [IsGetter], [IsSetter])
        //   VALUES (@ClassId, @MemberType, @MemberName, @FullName, @Declaration, @Documentation, @Description, @Version, NULL, NULL, 0, NULL, -1, GETDATE(), -1, GETDATE(), @IsAbstract, @IsPrivate, @IsStatic, @IsGetter, @IsSetter);
        // UPDATE dbo.Connect_ApiBrowser_Members
        //  SET [AppearedInVersion]=@Version, [FullName]=@FullName
        //  WHERE [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName AND [IsAbstract]=@IsAbstract AND [IsPrivate]=@IsPrivate AND [IsStatic]=@IsStatic AND [IsGetter]=@IsGetter AND [IsSetter]=@IsSetter AND [AppearedInVersion]>@Version;
        // IF @IsDeprecated=1
        // BEGIN
        //  IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_Members WHERE [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName AND [IsAbstract]=@IsAbstract AND [IsPrivate]=@IsPrivate AND [IsStatic]=@IsStatic AND [IsGetter]=@IsGetter AND [IsSetter]=@IsSetter
        //   AND ISNULL([DeprecatedInVersion],'99.99.99') < @Version)
        //  UPDATE dbo.Connect_ApiBrowser_Members
        //   SET [DeprecatedInVersion]=@Version,
        //    [IsDeprecated]=1,
        //    [DeprecationMessage]=ISNULL([DeprecationMessage], @DeprecationMessage)
        //  WHERE [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName AND [IsAbstract]=@IsAbstract AND [IsPrivate]=@IsPrivate AND [IsStatic]=@IsStatic AND [IsGetter]=@IsGetter AND [IsSetter]=@IsSetter;
        // END;
        // UPDATE dbo.Connect_ApiBrowser_Members
        //  SET [Declaration]=ISNULL([Declaration],@Declaration),
        //   [Documentation]=ISNULL([Documentation],@Documentation)
        //  WHERE
        //   [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName AND [IsAbstract]=@IsAbstract AND [IsPrivate]=@IsPrivate AND [IsStatic]=@IsStatic AND [IsGetter]=@IsGetter AND [IsSetter]=@IsSetter;
        // SELECT
        //  *
        // FROM dbo.Connect_ApiBrowser_Members
        // WHERE
        //  [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName AND [IsAbstract]=@IsAbstract AND [IsPrivate]=@IsPrivate AND [IsStatic]=@IsStatic AND [IsGetter]=@IsGetter AND [IsSetter]=@IsSetter;
        // ;  
        public static IEnumerable<object> GetOrCreateMember(int ClassId, int MemberType, string MemberName, string FullName, string Declaration, string Documentation, string Description, string Version, bool IsDeprecated, string DeprecationMessage, bool IsAbstract, bool IsPrivate, bool IsStatic, bool IsGetter, bool IsSetter)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<object>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateMember",
                    ClassId, MemberType, MemberName, FullName, Declaration, Documentation, Description, Version, IsDeprecated, DeprecationMessage, IsAbstract, IsPrivate, IsStatic, IsGetter, IsSetter);
            }
        }

        // IF NOT EXISTS(SELECT * FROM dbo.Connect_ApiBrowser_MemberCodeBlocks WHERE [MemberId]=@MemberId AND [Version]=@Version AND [CodeHash]=@CodeHash)
        //  INSERT INTO dbo.Connect_ApiBrowser_MemberCodeBlocks ([CodeHash], [EndColumn], [EndLine], [FileName], [MemberId], [StartColumn], [StartLine], [Version])
        //   VALUES (@CodeHash, @EndColumn, @EndLine, @FileName, @MemberId, @StartColumn, @StartLine, @Version);
        // SELECT * FROM dbo.Connect_ApiBrowser_MemberCodeBlocks WHERE [MemberId]=@MemberId AND [Version]=@Version AND [CodeHash]=@CodeHash;;  
        public static IEnumerable<object> GetOrCreateMemberCodeBlock(int MemberId, string CodeHash, string Version, string FileName, int StartLine, int StartColumn, int EndLine, int EndColumn)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<object>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateMemberCodeBlock",
                    MemberId, CodeHash, Version, FileName, StartLine, StartColumn, EndLine, EndColumn);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_ApiNamespaces WHERE [ModuleId]=@ModuleId AND [NamespaceName]=@NamespaceName)
        //  INSERT INTO dbo.Connect_ApiBrowser_ApiNamespaces ([ModuleId], [ParentId], [NamespaceName], [LastQualifier])
        //   VALUES (@ModuleId, @ParentId, @NamespaceName, @LastQualifier);
        // SELECT *
        //  FROM dbo.Connect_ApiBrowser_ApiNamespaces
        //  WHERE [ModuleId]=@ModuleId
        //    AND [NamespaceName]=@NamespaceName;;  
        public static IEnumerable<object> GetOrCreateNamespace(int ModuleId, int ParentId, string NamespaceName, string LastQualifier)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<object>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateNamespace",
                    ModuleId, ParentId, NamespaceName, LastQualifier);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_References WHERE [CodeBlockId]=@CodeBlockId AND [FullName]=@FullName)
        // INSERT INTO dbo.Connect_ApiBrowser_References ([CodeBlockId],[FullName],[Offset])
        // VALUES (@CodeBlockId, @FullName, @Offset)
        // SELECT * FROM dbo.vw_Connect_ApiBrowser_References
        // WHERE [CodeBlockId]=@CodeBlockId AND [FullName]=@FullName;  
        public static IEnumerable<object> GetOrCreateReference(int CodeBlockId, string FullName, int Offset)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<object>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateReference",
                    CodeBlockId, FullName, Offset);
            }
        }

        // UPDATE dbo.Connect_ApiBrowser_Members
        //  SET [DisappearedInVersion]=@Version
        //  WHERE [MemberId]=@MemberId
        //   AND ISNULL([DisappearedInVersion],'99.99.99') > @Version;  
        public static void MemberDisappeared(int MemberId, string Version)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_MemberDisappeared",
                    MemberId, Version);
            }
        }

        // UPDATE dbo.Connect_ApiBrowser_Dependencies
        // SET [DepComponentHistoryId]=childch.ComponentHistoryId
        // FROM
        // dbo.Connect_ApiBrowser_Dependencies d
        // INNER JOIN dbo.Connect_ApiBrowser_ComponentHistories ch ON ch.ComponentHistoryId=d.ComponentHistoryId
        // INNER JOIN dbo.Connect_ApiBrowser_Components c ON c.ComponentId=ch.ComponentId
        // INNER JOIN dbo.Connect_ApiBrowser_ComponentHistories childch ON childch.FullName=d.FullName
        // INNER JOIN dbo.Connect_ApiBrowser_Components childc ON childc.ComponentId=childch.ComponentId AND childc.ModuleId=c.ModuleId
        // WHERE c.ModuleId=@ModuleId
        // AND d.DepComponentHistoryId IS NULL;  
        public static void UpdateDependencies(int ModuleId)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_UpdateDependencies",
                    ModuleId);
            }
        }

        // UPDATE dbo.Connect_ApiBrowser_References
        // SET [ReferencedMemberId]=childm.MemberId
        // FROM dbo.Connect_ApiBrowser_References r
        // INNER JOIN dbo.Connect_ApiBrowser_MemberCodeBlocks mcb ON mcb.CodeBlockId=r.CodeBlockId
        // INNER JOIN dbo.Connect_ApiBrowser_Members m ON m.MemberId=mcb.MemberId
        // INNER JOIN dbo.Connect_ApiBrowser_ApiClasses c ON c.ClassId=m.ClassId
        // INNER JOIN dbo.Connect_ApiBrowser_ComponentHistories ch ON ch.ComponentId=c.ComponentId AND mcb.Version=ch.Version
        // INNER JOIN dbo.Connect_ApiBrowser_ApiNamespaces n ON n.NamespaceId=c.NamespaceId
        // INNER JOIN dbo.Connect_ApiBrowser_Members childm ON childm.FullName=r.FullName
        // INNER JOIN dbo.Connect_ApiBrowser_ApiClasses childc ON childc.ClassId=childm.ClassId
        // INNER JOIN dbo.Connect_ApiBrowser_ComponentHistories childch ON childch.ComponentId=childc.ComponentId AND childch.ComponentId=ch.ComponentId
        // INNER JOIN dbo.Connect_ApiBrowser_ApiNamespaces childn ON childn.NamespaceId=childc.NamespaceId
        // WHERE n.ModuleId=@ModuleId
        // AND childn.ModuleId=@ModuleId
        // AND r.ReferencedMemberId IS NULL;
        // UPDATE dbo.Connect_ApiBrowser_References
        // SET [ReferencedMemberId]=childm.MemberId
        // FROM dbo.Connect_ApiBrowser_References r
        // INNER JOIN dbo.Connect_ApiBrowser_MemberCodeBlocks mcb ON mcb.CodeBlockId=r.CodeBlockId
        // INNER JOIN dbo.Connect_ApiBrowser_Members m ON m.MemberId=mcb.MemberId
        // INNER JOIN dbo.Connect_ApiBrowser_ApiClasses c ON c.ClassId=m.ClassId
        // INNER JOIN dbo.Connect_ApiBrowser_ComponentHistories ch ON ch.ComponentId=c.ComponentId AND mcb.Version=ch.Version
        // INNER JOIN dbo.Connect_ApiBrowser_ApiNamespaces n ON n.NamespaceId=c.NamespaceId
        // INNER JOIN dbo.Connect_ApiBrowser_Members childm ON childm.FullName=r.FullName
        // INNER JOIN dbo.Connect_ApiBrowser_ApiClasses childc ON childc.ClassId=childm.ClassId
        // INNER JOIN dbo.Connect_ApiBrowser_ComponentHistories childch ON childch.ComponentId=childc.ComponentId
        // INNER JOIN dbo.Connect_ApiBrowser_ApiNamespaces childn ON childn.NamespaceId=childc.NamespaceId
        // INNER JOIN dbo.Connect_ApiBrowser_Dependencies d ON d.ComponentHistoryId=ch.ComponentHistoryId
        // WHERE n.ModuleId=@ModuleId
        // AND childn.ModuleId=@ModuleId
        // AND d.DepComponentHistoryId=childch.ComponentHistoryId
        // AND r.ReferencedMemberId IS NULL;;  
        public static void UpdateReferences(int ModuleId)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_UpdateReferences",
                    ModuleId);
            }
        }

    }
}

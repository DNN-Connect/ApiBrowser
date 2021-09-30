using System.Collections.Generic;
using DotNetNuke.Data;
using Connect.ApiBrowser.Core.Models.ApiClasses;
using Connect.ApiBrowser.Core.Models.Components;
using Connect.ApiBrowser.Core.Models.Members;
using Connect.ApiBrowser.Core.Models.ApiNamespaces;
using Connect.ApiBrowser.Core.Models;
using Connect.ApiBrowser.Core.Models.ComponentHistories;
using Connect.ApiBrowser.Core.Models.Dependencies;
using Connect.ApiBrowser.Core.Models.References;
using Connect.ApiBrowser.Core.Models.MemberCodeBlocks;

namespace Connect.ApiBrowser.Core.Data
{
    public class Sprocs
    {
        // UPDATE dbo.Connect_ApiBrowser_ApiClasses
        //  SET [DisappearedInVersion]=@Version
        //  WHERE [ClassId]=@ClassId
        //   AND ISNULL([DisappearedInVersion],'99.99.99') > @Version
        // ;  
        public static void ClassDisappeared(int classId, string version)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_ClassDisappeared",
                    classId, version);
            }
        }

        // SELECT
        //  c.*,
        //  (SELECT COUNT(*) FROM dbo.Connect_ApiBrowser_ApiClasses cl WHERE cl.ComponentId=c.ComponentId) NrClasses,
        //  (SELECT COUNT(*) FROM dbo.Connect_ApiBrowser_ApiClasses cl WHERE cl.ComponentId=c.ComponentId AND ISNULL(cl.DocumentationId, -1) <> -1) NrDocumentedClasses,
        //  (SELECT COUNT(*) FROM dbo.Connect_ApiBrowser_Members m INNER JOIN dbo.Connect_ApiBrowser_ApiClasses cl ON m.ClassId=cl.ClassId WHERE cl.ComponentId=c.ComponentId) NrMembers,
        //  (SELECT COUNT(*) FROM dbo.Connect_ApiBrowser_Members m INNER JOIN dbo.Connect_ApiBrowser_ApiClasses cl ON m.ClassId=cl.ClassId WHERE cl.ComponentId=c.ComponentId AND ISNULL(m.DocumentationId, -1) <> -1) NrDocumentedMembers
        // FROM dbo.Connect_ApiBrowser_Components c
        // WHERE c.ModuleId=@ModuleId
        // ;  
        public static IEnumerable<ComponentWithStats> GetComponents(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<ComponentWithStats>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetComponents",
                    moduleId);
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
        // ORDER BY x.FullQualifier, x.LastModifiedOnDate
        // 
        // 
        // ;  
        public static IEnumerable<ModerationItem> GetModerationList(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<ModerationItem>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetModerationList",
                    moduleId);
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
        // ORDER BY x.[Name]
        // ;  
        public static IEnumerable<ApiClassOrNamespace> GetNamespacesAndClasses(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteQuery<ApiClassOrNamespace>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetNamespacesAndClasses",
                    moduleId);
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
        //  [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ParentClassId]=@ParentClassId AND [ClassName]=@ClassName;;  
        public static ApiClass GetOrCreateClass(int namespaceId, int componentId, int parentClassId, string className, string fullName, string declaration, string documentation, string description, string version, bool isDeprecated, string deprecationMessage, bool isAbstract, bool isAnsiClass, bool isArray, bool isAutoClass, bool isAutoLayout, bool isBeforeFieldInit, bool isByReference, bool isClass, bool isDefinition, bool isEnum, bool isExplicitLayout, bool isFunctionPointer, bool isGenericInstance, bool isGenericParameter, bool isImport, bool isInterface, bool isNested, bool isNestedAssembly, bool isNestedPrivate, bool isNestedPublic, bool isNotPublic)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<ApiClass>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateClass",
                    namespaceId, componentId, parentClassId, className, fullName, declaration, documentation, description, version, isDeprecated, deprecationMessage, isAbstract, isAnsiClass, isArray, isAutoClass, isAutoLayout, isBeforeFieldInit, isByReference, isClass, isDefinition, isEnum, isExplicitLayout, isFunctionPointer, isGenericInstance, isGenericParameter, isImport, isInterface, isNested, isNestedAssembly, isNestedPrivate, isNestedPublic, isNotPublic);
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
        //    AND [ComponentName]=@ComponentName;
        // ;  
        public static Component GetOrCreateComponent(int moduleId, string componentName, string latestVersion)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<Component>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateComponent",
                    moduleId, componentName, latestVersion);
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
        //  WHERE [ComponentId]=@ComponentId AND [Version]=@Version;
        // 
        // ;  
        public static ComponentHistory GetOrCreateComponentHistory(int componentId, string fullName, string version, string versionNormalized, int codeLines, int commentLines, int emptyLines)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<ComponentHistory>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateComponentHistory",
                    componentId, fullName, version, versionNormalized, codeLines, commentLines, emptyLines);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_Dependencies WHERE [ComponentHistoryId]=@ComponentHistoryId AND [FullName]=@FullName)
        // INSERT INTO [dbo].[Connect_ApiBrowser_Dependencies]
        // ([ComponentHistoryId],[FullName],[Version],[VersionNormalized],[Name])
        // VALUES (@ComponentHistoryId, @FullName, @Version, @VersionNormalized, @Name)
        // ELSE
        // UPDATE dbo.Connect_ApiBrowser_Dependencies
        // SET [Version]=@Version, [VersionNormalized]=@VersionNormalized, [Name]=@Name
        // WHERE [ComponentHistoryId]=@ComponentHistoryId AND [FullName]=@FullName
        // SELECT * FROM dbo.vw_Connect_ApiBrowser_Dependencies
        // WHERE [ComponentHistoryId]=@ComponentHistoryId AND [FullName]=@FullName
        // ;  
        public static Dependency GetOrCreateDependency(int componentHistoryId, string fullName, string version, string versionNormalized, string name)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<Dependency>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateDependency",
                    componentHistoryId, fullName, version, versionNormalized, name);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_Members WHERE [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName)
        //  INSERT INTO dbo.Connect_ApiBrowser_Members ([ClassId],[MemberType],[MemberName],[FullName],[Declaration],[Documentation],[Description], [AppearedInVersion],[DeprecatedInVersion],[DisappearedInVersion],[IsDeprecated],[DeprecationMessage], [CreatedByUserID], [CreatedOnDate], [LastModifiedByUserID], [LastModifiedOnDate])
        //   VALUES (@ClassId, @MemberType, @MemberName, @FullName, @Declaration, @Documentation, @Description, @Version, NULL, NULL, 0, NULL, -1, GETDATE(), -1, GETDATE());
        // UPDATE dbo.Connect_ApiBrowser_Members
        //  SET [AppearedInVersion]=@Version, [FullName]=@FullName
        //  WHERE [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName AND [AppearedInVersion]>@Version;
        // IF @IsDeprecated=1
        // BEGIN
        //  IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_Members WHERE [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName
        //   AND ISNULL([DeprecatedInVersion],'99.99.99') < @Version)
        //  UPDATE dbo.Connect_ApiBrowser_Members
        //   SET [DeprecatedInVersion]=@Version,
        //    [IsDeprecated]=1,
        //    [DeprecationMessage]=ISNULL([DeprecationMessage], @DeprecationMessage)
        //  WHERE [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName;
        // END;
        // UPDATE dbo.Connect_ApiBrowser_Members
        //  SET [Declaration]=ISNULL([Declaration],@Declaration),
        //   [Documentation]=ISNULL([Documentation],@Documentation)
        //  WHERE
        //   [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName;
        // SELECT
        //  *
        // FROM dbo.Connect_ApiBrowser_Members
        // WHERE
        //  [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName;
        // ;  
        public static Member GetOrCreateMember(int classId, int memberType, string memberName, string fullName, string declaration, string documentation, string description, string version, bool isDeprecated, string deprecationMessage)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<Member>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateMember",
                    classId, memberType, memberName, fullName, declaration, documentation, description, version, isDeprecated, deprecationMessage);
            }
        }

        // IF NOT EXISTS(SELECT * FROM dbo.Connect_ApiBrowser_MemberCodeBlocks WHERE [MemberId]=@MemberId AND [Version]=@Version)
        //  INSERT INTO dbo.Connect_ApiBrowser_MemberCodeBlocks ([CodeHash], [EndColumn], [EndLine], [FileName], [MemberId], [StartColumn], [StartLine], [Version])
        //   VALUES (@CodeHash, @EndColumn, @EndLine, @FileName, @MemberId, @StartColumn, @StartLine, @Version);
        // SELECT * FROM dbo.Connect_ApiBrowser_MemberCodeBlocks WHERE [MemberId]=@MemberId AND [Version]=@Version;
        // 
        // ;  
        public static MemberCodeBlock GetOrCreateMemberCodeBlock(int memberId, string codeHash, string version, string fileName, int startLine, int startColumn, int endLine, int endColumn)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<MemberCodeBlock>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateMemberCodeBlock",
                    memberId, codeHash, version, fileName, startLine, startColumn, endLine, endColumn);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_ApiNamespaces WHERE [ModuleId]=@ModuleId AND [NamespaceName]=@NamespaceName)
        //  INSERT INTO dbo.Connect_ApiBrowser_ApiNamespaces ([ModuleId], [ParentId], [NamespaceName], [LastQualifier])
        //   VALUES (@ModuleId, @ParentId, @NamespaceName, @LastQualifier);
        // SELECT *
        //  FROM dbo.Connect_ApiBrowser_ApiNamespaces
        //  WHERE [ModuleId]=@ModuleId
        //    AND [NamespaceName]=@NamespaceName;
        // ;  
        public static ApiNamespace GetOrCreateNamespace(int moduleId, int parentId, string namespaceName, string lastQualifier)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<ApiNamespace>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateNamespace",
                    moduleId, parentId, namespaceName, lastQualifier);
            }
        }

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_References WHERE [CodeBlockId]=@CodeBlockId AND [FullName]=@FullName)
        // INSERT INTO dbo.Connect_ApiBrowser_References ([CodeBlockId],[FullName],[Offset])
        // VALUES (@CodeBlockId, @FullName, @Offset)
        // SELECT * FROM dbo.vw_Connect_ApiBrowser_References
        // WHERE [CodeBlockId]=@CodeBlockId AND [FullName]=@FullName
        // ;  
        public static Reference GetOrCreateReference(int codeBlockId, string fullName, int offset)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<Reference>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateReference",
                    codeBlockId, fullName, offset);
            }
        }

        // UPDATE dbo.Connect_ApiBrowser_Members
        //  SET [DisappearedInVersion]=@Version
        //  WHERE [MemberId]=@MemberId
        //   AND ISNULL([DisappearedInVersion],'99.99.99') > @Version
        // ;  
        public static void MemberDisappeared(int memberId, string version)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_MemberDisappeared",
                    memberId, version);
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
        // AND d.DepComponentHistoryId IS NULL
        // 
        // ;  
        public static void UpdateDependencies(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_UpdateDependencies",
                    moduleId);
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
        // AND r.ReferencedMemberId IS NULL;
        // 
        // ;  
        public static void UpdateReferences(int moduleId)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_UpdateReferences",
                    moduleId);
            }
        }

    }
}

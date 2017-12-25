using System.Collections.Generic;
using DotNetNuke.Data;
using Connect.ApiBrowser.Core.Models.ApiClasses;
using Connect.ApiBrowser.Core.Models.Components;
using Connect.ApiBrowser.Core.Models.Members;
using Connect.ApiBrowser.Core.Models.ApiNamespaces;
using Connect.ApiBrowser.Core.Models;

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

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_ApiClasses WHERE [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ClassName]=@ClassName)
        //  INSERT INTO dbo.Connect_ApiBrowser_ApiClasses ([NamespaceId], [ComponentId], [ClassName], [Declaration], [Documentation], [Description],[AppearedInVersion], [DeprecatedInVersion], [DisappearedInVersion], [IsDeprecated], [DeprecationMessage])
        //   VALUES (@NamespaceId, @ComponentId, @ClassName, @Declaration, @Documentation, @Description, @Version, NULL, NULL, 0, NULL);
        // UPDATE dbo.Connect_ApiBrowser_ApiClasses
        //  SET [AppearedInVersion]=@Version
        //  WHERE [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ClassName]=@ClassName AND [AppearedInVersion]>@Version;
        // IF @IsDeprecated=1
        // BEGIN
        //  IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_ApiClasses WHERE [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ClassName]=@ClassName
        //   AND ISNULL([DeprecatedInVersion],'99.99.99') < @Version)
        //  UPDATE dbo.Connect_ApiBrowser_ApiClasses
        //   SET [DeprecatedInVersion]=@Version,
        //    [IsDeprecated]=1,
        //    [DeprecationMessage]=ISNULL([DeprecationMessage], @DeprecationMessage)
        //   WHERE [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ClassName]=@ClassName;
        // END;
        // UPDATE dbo.Connect_ApiBrowser_ApiClasses
        //  SET [Declaration]=ISNULL([Declaration],@Declaration),
        //   [Documentation]=ISNULL([Documentation],@Documentation)
        //  WHERE
        //   [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ClassName]=@ClassName;
        // SELECT
        //  *
        // FROM dbo.Connect_ApiBrowser_ApiClasses
        // WHERE
        //  [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ClassName]=@ClassName;
        // ;  
        public static ApiClass GetOrCreateClass(int namespaceId, int componentId, string className, string declaration, string documentation, string description, string version, bool isDeprecated, string deprecationMessage)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<ApiClass>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateClass",
                    namespaceId, componentId, className, declaration, documentation, description, version, isDeprecated, deprecationMessage);
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

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_Members WHERE [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName)
        //  INSERT INTO dbo.Connect_ApiBrowser_Members ([ClassId],[MemberType],[MemberName],[Declaration],[Documentation],[Description], [AppearedInVersion],[DeprecatedInVersion],[DisappearedInVersion],[IsDeprecated],[DeprecationMessage])
        //   VALUES (@ClassId, @MemberType, @MemberName, @Declaration, @Documentation, @Description, @Version, NULL, NULL, 0, NULL);
        // UPDATE dbo.Connect_ApiBrowser_Members
        //  SET [AppearedInVersion]=@Version
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
        public static Member GetOrCreateMember(int classId, int memberType, string memberName, string declaration, string documentation, string description, string version, bool isDeprecated, string deprecationMessage)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<Member>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateMember",
                    classId, memberType, memberName, declaration, documentation, description, version, isDeprecated, deprecationMessage);
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

        // IF NOT EXISTS(SELECT * FROM dbo.Connect_ApiBrowser_MemberCodeBlocks WHERE [MemberId]=@MemberId AND [Version]=@Version)
        //  INSERT INTO dbo.Connect_ApiBrowser_MemberCodeBlocks ([CodeHash], [EndColumn], [EndLine], [FileName], [MemberId], [StartColumn], [StartLine], [Version])
        //   VALUES (@CodeHash, @EndColumn, @EndLine, @FileName, @MemberId, @StartColumn, @StartLine, @Version);
        // ;  
        public static void RegisterCodeBlock(int memberId, string codeHash, string version, string fileName, int startLine, int startColumn, int endLine, int endColumn)
        {
            using (var context = DataContext.Instance())
            {
                context.Execute(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_RegisterCodeBlock",
                    memberId, codeHash, version, fileName, startLine, startColumn, endLine, endColumn);
            }
        }

    }
}

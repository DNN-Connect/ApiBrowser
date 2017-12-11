using System.Collections.Generic;
using DotNetNuke.Data;
using Connect.ApiBrowser.Core.Models.ApiClasses;
using Connect.ApiBrowser.Core.Models.Components;
using Connect.ApiBrowser.Core.Models.Members;
using Connect.ApiBrowser.Core.Models.ApiNamespaces;

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

        // IF NOT EXISTS (SELECT * FROM dbo.Connect_ApiBrowser_ApiClasses WHERE [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ClassName]=@ClassName)
        //  INSERT INTO dbo.Connect_ApiBrowser_ApiClasses ([NamespaceId], [ComponentId], [ClassName], [Declaration], [Documentation], [AppearedInVersion], [DeprecatedInVersion], [DisappearedInVersion], [IsDeprecated], [DeprecationMessage])
        //   VALUES (@NamespaceId, @ComponentId, @ClassName, @Declaration, @Documentation, @Version, NULL, NULL, 0, NULL);
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
        //  [NamespaceId]=@NamespaceId AND [ComponentId]=@ComponentId AND [ClassName]=@ClassName;;  
        public static ApiClass GetOrCreateClass(int namespaceId, int componentId, string className, string declaration, string documentation, string version, bool isDeprecated, string deprecationMessage)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<ApiClass>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateClass",
                    namespaceId, componentId, className, declaration, documentation, version, isDeprecated, deprecationMessage);
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
        //  INSERT INTO dbo.Connect_ApiBrowser_Members ([ClassId],[MemberType],[MemberName],[Declaration],[Documentation],[AppearedInVersion],[DeprecatedInVersion],[DisappearedInVersion],[IsDeprecated],[DeprecationMessage])
        //   VALUES (@ClassId, @MemberType, @MemberName, @Declaration, @Documentation, @Version, NULL, NULL, 0, NULL);
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
        //  [ClassId]=@ClassId AND [MemberType]=@MemberType AND [MemberName]=@MemberName;;  
        public static Member GetOrCreateMember(int classId, int memberType, string memberName, string declaration, string documentation, string version, bool isDeprecated, string deprecationMessage)
        {
            using (var context = DataContext.Instance())
            {
                return context.ExecuteSingleOrDefault<Member>(System.Data.CommandType.StoredProcedure,
                    "Connect_ApiBrowser_GetOrCreateMember",
                    classId, memberType, memberName, declaration, documentation, version, isDeprecated, deprecationMessage);
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
        //   AND ISNULL([DisappearedInVersion],'99.99.99') > @Version;  
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

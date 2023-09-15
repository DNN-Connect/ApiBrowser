
        ws[$"{column}{row}"].SetValue(input.ClassId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.NamespaceId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ComponentId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ClassName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Declaration);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Documentation);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Description);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.AppearedInVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.DeprecatedInVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.DisappearedInVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsDeprecated, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.DeprecationMessage);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.DocumentationId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.PendingDescription);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FullName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsAbstract, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsAnsiClass, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsArray, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsAutoClass, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsAutoLayout, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsBeforeFieldInit, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsByReference, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsClass, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsDefinition, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsEnum, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsExplicitLayout, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsFunctionPointer, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsGenericInstance, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsGenericParameter, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsImport, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsInterface, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsNested, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsNestedAssembly, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsNestedPrivate, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsNestedPublic, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsNotPublic, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ParentClassId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.CreatedByUserDisplayName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.LastModifiedByUserDisplayName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.DocumentationContents);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.NamespaceName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FullQualifier);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ModuleId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ComponentName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.LatestVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.MemberCount, userUnits["um"]);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "ClassId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ClassId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "NamespaceId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("NamespaceId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ComponentId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ComponentId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ClassName";
        ws[$"{column}{row + 1}"].Text = GetString("ClassName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Declaration";
        ws[$"{column}{row + 1}"].Text = GetString("Declaration");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Documentation";
        ws[$"{column}{row + 1}"].Text = GetString("Documentation");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Description";
        ws[$"{column}{row + 1}"].Text = GetString("Description");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "AppearedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("AppearedInVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "DeprecatedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("DeprecatedInVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "DisappearedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("DisappearedInVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsDeprecated;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsDeprecated") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "DeprecationMessage";
        ws[$"{column}{row + 1}"].Text = GetString("DeprecationMessage");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "DocumentationId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("DocumentationId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "PendingDescription";
        ws[$"{column}{row + 1}"].Text = GetString("PendingDescription");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FullName";
        ws[$"{column}{row + 1}"].Text = GetString("FullName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsAbstract;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsAbstract") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsAnsiClass;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsAnsiClass") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsArray;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsArray") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsAutoClass;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsAutoClass") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsAutoLayout;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsAutoLayout") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsBeforeFieldInit;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsBeforeFieldInit") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsByReference;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsByReference") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsClass;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsClass") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsDefinition;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsDefinition") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsEnum;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsEnum") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsExplicitLayout;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsExplicitLayout") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsFunctionPointer;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsFunctionPointer") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsGenericInstance;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsGenericInstance") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsGenericParameter;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsGenericParameter") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsImport;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsImport") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsInterface;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsInterface") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsNested;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsNested") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsNestedAssembly;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsNestedAssembly") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsNestedPrivate;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsNestedPrivate") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsNestedPublic;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsNestedPublic") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsNotPublic;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsNotPublic") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ParentClassId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ParentClassId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "CreatedByUserDisplayName";
        ws[$"{column}{row + 1}"].Text = GetString("CreatedByUserDisplayName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "LastModifiedByUserDisplayName";
        ws[$"{column}{row + 1}"].Text = GetString("LastModifiedByUserDisplayName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "DocumentationContents";
        ws[$"{column}{row + 1}"].Text = GetString("DocumentationContents");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "NamespaceName";
        ws[$"{column}{row + 1}"].Text = GetString("NamespaceName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FullQualifier";
        ws[$"{column}{row + 1}"].Text = GetString("FullQualifier");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ModuleId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ModuleId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ComponentName";
        ws[$"{column}{row + 1}"].Text = GetString("ComponentName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "LatestVersion";
        ws[$"{column}{row + 1}"].Text = GetString("LatestVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "MemberCount;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("MemberCount") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();

            case "ClassId":
              mp.ClassId = ws[$"{crtCol}{row}"].Text;
              break;
            case "NamespaceId":
              mp.NamespaceId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ComponentId":
              mp.ComponentId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ClassName":
              mp.ClassName = ws[$"{crtCol}{row}"].Text;
              break;
            case "Declaration":
              mp.Declaration = ws[$"{crtCol}{row}"].Text;
              break;
            case "Documentation":
              mp.Documentation = ws[$"{crtCol}{row}"].Text;
              break;
            case "Description":
              mp.Description = ws[$"{crtCol}{row}"].Text;
              break;
            case "AppearedInVersion":
              mp.AppearedInVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "DeprecatedInVersion":
              mp.DeprecatedInVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "DisappearedInVersion":
              mp.DisappearedInVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsDeprecated":
              mp.IsDeprecated = ws[$"{crtCol}{row}"].Text;
              break;
            case "DeprecationMessage":
              mp.DeprecationMessage = ws[$"{crtCol}{row}"].Text;
              break;
            case "DocumentationId":
              mp.DocumentationId = ws[$"{crtCol}{row}"].Text;
              break;
            case "PendingDescription":
              mp.PendingDescription = ws[$"{crtCol}{row}"].Text;
              break;
            case "FullName":
              mp.FullName = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsAbstract":
              mp.IsAbstract = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsAnsiClass":
              mp.IsAnsiClass = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsArray":
              mp.IsArray = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsAutoClass":
              mp.IsAutoClass = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsAutoLayout":
              mp.IsAutoLayout = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsBeforeFieldInit":
              mp.IsBeforeFieldInit = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsByReference":
              mp.IsByReference = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsClass":
              mp.IsClass = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsDefinition":
              mp.IsDefinition = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsEnum":
              mp.IsEnum = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsExplicitLayout":
              mp.IsExplicitLayout = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsFunctionPointer":
              mp.IsFunctionPointer = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsGenericInstance":
              mp.IsGenericInstance = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsGenericParameter":
              mp.IsGenericParameter = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsImport":
              mp.IsImport = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsInterface":
              mp.IsInterface = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsNested":
              mp.IsNested = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsNestedAssembly":
              mp.IsNestedAssembly = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsNestedPrivate":
              mp.IsNestedPrivate = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsNestedPublic":
              mp.IsNestedPublic = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsNotPublic":
              mp.IsNotPublic = ws[$"{crtCol}{row}"].Text;
              break;
            case "ParentClassId":
              mp.ParentClassId = ws[$"{crtCol}{row}"].Text;
              break;
            case "CreatedByUserDisplayName":
              mp.CreatedByUserDisplayName = ws[$"{crtCol}{row}"].Text;
              break;
            case "LastModifiedByUserDisplayName":
              mp.LastModifiedByUserDisplayName = ws[$"{crtCol}{row}"].Text;
              break;
            case "DocumentationContents":
              mp.DocumentationContents = ws[$"{crtCol}{row}"].Text;
              break;
            case "NamespaceName":
              mp.NamespaceName = ws[$"{crtCol}{row}"].Text;
              break;
            case "FullQualifier":
              mp.FullQualifier = ws[$"{crtCol}{row}"].Text;
              break;
            case "ModuleId":
              mp.ModuleId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ComponentName":
              mp.ComponentName = ws[$"{crtCol}{row}"].Text;
              break;
            case "LatestVersion":
              mp.LatestVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "MemberCount":
              mp.MemberCount = ws[$"{crtCol}{row}"].Text;
              break;

            this.ClassId = mp.ClassId;
            this.NamespaceId = mp.NamespaceId;
            this.ComponentId = mp.ComponentId;
            this.ClassName = mp.ClassName;
            this.Declaration = mp.Declaration;
            this.Documentation = mp.Documentation;
            this.Description = mp.Description;
            this.AppearedInVersion = mp.AppearedInVersion;
            this.DeprecatedInVersion = mp.DeprecatedInVersion;
            this.DisappearedInVersion = mp.DisappearedInVersion;
            this.IsDeprecated = mp.IsDeprecated;
            this.DeprecationMessage = mp.DeprecationMessage;
            this.DocumentationId = mp.DocumentationId;
            this.PendingDescription = mp.PendingDescription;
            this.FullName = mp.FullName;
            this.IsAbstract = mp.IsAbstract;
            this.IsAnsiClass = mp.IsAnsiClass;
            this.IsArray = mp.IsArray;
            this.IsAutoClass = mp.IsAutoClass;
            this.IsAutoLayout = mp.IsAutoLayout;
            this.IsBeforeFieldInit = mp.IsBeforeFieldInit;
            this.IsByReference = mp.IsByReference;
            this.IsClass = mp.IsClass;
            this.IsDefinition = mp.IsDefinition;
            this.IsEnum = mp.IsEnum;
            this.IsExplicitLayout = mp.IsExplicitLayout;
            this.IsFunctionPointer = mp.IsFunctionPointer;
            this.IsGenericInstance = mp.IsGenericInstance;
            this.IsGenericParameter = mp.IsGenericParameter;
            this.IsImport = mp.IsImport;
            this.IsInterface = mp.IsInterface;
            this.IsNested = mp.IsNested;
            this.IsNestedAssembly = mp.IsNestedAssembly;
            this.IsNestedPrivate = mp.IsNestedPrivate;
            this.IsNestedPublic = mp.IsNestedPublic;
            this.IsNotPublic = mp.IsNotPublic;
            this.ParentClassId = mp.ParentClassId;
            this.CreatedByUserDisplayName = mp.CreatedByUserDisplayName;
            this.LastModifiedByUserDisplayName = mp.LastModifiedByUserDisplayName;
            this.DocumentationContents = mp.DocumentationContents;
            this.NamespaceName = mp.NamespaceName;
            this.FullQualifier = mp.FullQualifier;
            this.ModuleId = mp.ModuleId;
            this.ComponentName = mp.ComponentName;
            this.LatestVersion = mp.LatestVersion;
            this.MemberCount = mp.MemberCount;


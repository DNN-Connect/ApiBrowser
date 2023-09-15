
        ws[$"{column}{row}"].SetValue(input.MemberId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ClassId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.MemberType, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.MemberName);
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
        ws[$"{column}{row}"].SetValue(input.IsPrivate, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsStatic, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsGetter, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsSetter, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.CreatedByUserDisplayName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.LastModifiedByUserDisplayName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.DocumentationContents);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ClassName);
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
        ws[$"{column}{row}"].SetValue(input.CodeBlockCount, userUnits["um"]);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "MemberId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("MemberId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ClassId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ClassId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "MemberType;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("MemberType") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "MemberName";
        ws[$"{column}{row + 1}"].Text = GetString("MemberName");
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
        ws[$"{column}{row}"].Text = "IsPrivate;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsPrivate") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsStatic;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsStatic") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsGetter;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsGetter") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsSetter;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsSetter") + " (" + userUnits["um"].Suffix + ")";
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
        ws[$"{column}{row}"].Text = "ClassName";
        ws[$"{column}{row + 1}"].Text = GetString("ClassName");
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
        ws[$"{column}{row}"].Text = "CodeBlockCount;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("CodeBlockCount") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();

            case "MemberId":
              mp.MemberId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ClassId":
              mp.ClassId = ws[$"{crtCol}{row}"].Text;
              break;
            case "MemberType":
              mp.MemberType = ws[$"{crtCol}{row}"].Text;
              break;
            case "MemberName":
              mp.MemberName = ws[$"{crtCol}{row}"].Text;
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
            case "IsPrivate":
              mp.IsPrivate = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsStatic":
              mp.IsStatic = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsGetter":
              mp.IsGetter = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsSetter":
              mp.IsSetter = ws[$"{crtCol}{row}"].Text;
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
            case "ClassName":
              mp.ClassName = ws[$"{crtCol}{row}"].Text;
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
            case "CodeBlockCount":
              mp.CodeBlockCount = ws[$"{crtCol}{row}"].Text;
              break;

            this.MemberId = mp.MemberId;
            this.ClassId = mp.ClassId;
            this.MemberType = mp.MemberType;
            this.MemberName = mp.MemberName;
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
            this.IsPrivate = mp.IsPrivate;
            this.IsStatic = mp.IsStatic;
            this.IsGetter = mp.IsGetter;
            this.IsSetter = mp.IsSetter;
            this.CreatedByUserDisplayName = mp.CreatedByUserDisplayName;
            this.LastModifiedByUserDisplayName = mp.LastModifiedByUserDisplayName;
            this.DocumentationContents = mp.DocumentationContents;
            this.ClassName = mp.ClassName;
            this.NamespaceName = mp.NamespaceName;
            this.FullQualifier = mp.FullQualifier;
            this.ModuleId = mp.ModuleId;
            this.ComponentName = mp.ComponentName;
            this.LatestVersion = mp.LatestVersion;
            this.CodeBlockCount = mp.CodeBlockCount;


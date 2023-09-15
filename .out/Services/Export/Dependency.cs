
        ws[$"{column}{row}"].SetValue(input.DependencyId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ComponentHistoryId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FullName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Version);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.VersionNormalized);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Name);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.DepComponentHistoryId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ComponentName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.LatestVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.DependentComponentName);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "DependencyId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("DependencyId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ComponentHistoryId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ComponentHistoryId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FullName";
        ws[$"{column}{row + 1}"].Text = GetString("FullName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Version";
        ws[$"{column}{row + 1}"].Text = GetString("Version");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "VersionNormalized";
        ws[$"{column}{row + 1}"].Text = GetString("VersionNormalized");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Name";
        ws[$"{column}{row + 1}"].Text = GetString("Name");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "DepComponentHistoryId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("DepComponentHistoryId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ComponentName";
        ws[$"{column}{row + 1}"].Text = GetString("ComponentName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "LatestVersion";
        ws[$"{column}{row + 1}"].Text = GetString("LatestVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "DependentComponentName";
        ws[$"{column}{row + 1}"].Text = GetString("DependentComponentName");
        column = column.NextColumn();

            case "DependencyId":
              mp.DependencyId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ComponentHistoryId":
              mp.ComponentHistoryId = ws[$"{crtCol}{row}"].Text;
              break;
            case "FullName":
              mp.FullName = ws[$"{crtCol}{row}"].Text;
              break;
            case "Version":
              mp.Version = ws[$"{crtCol}{row}"].Text;
              break;
            case "VersionNormalized":
              mp.VersionNormalized = ws[$"{crtCol}{row}"].Text;
              break;
            case "Name":
              mp.Name = ws[$"{crtCol}{row}"].Text;
              break;
            case "DepComponentHistoryId":
              mp.DepComponentHistoryId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ComponentName":
              mp.ComponentName = ws[$"{crtCol}{row}"].Text;
              break;
            case "LatestVersion":
              mp.LatestVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "DependentComponentName":
              mp.DependentComponentName = ws[$"{crtCol}{row}"].Text;
              break;

            this.DependencyId = mp.DependencyId;
            this.ComponentHistoryId = mp.ComponentHistoryId;
            this.FullName = mp.FullName;
            this.Version = mp.Version;
            this.VersionNormalized = mp.VersionNormalized;
            this.Name = mp.Name;
            this.DepComponentHistoryId = mp.DepComponentHistoryId;
            this.ComponentName = mp.ComponentName;
            this.LatestVersion = mp.LatestVersion;
            this.DependentComponentName = mp.DependentComponentName;


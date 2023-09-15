
        ws[$"{column}{row}"].SetValue(input.ComponentId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ModuleId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ComponentName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.LatestVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Description);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "ComponentId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ComponentId") + " (" + userUnits["um"].Suffix + ")";
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
        ws[$"{column}{row}"].Text = "Description";
        ws[$"{column}{row + 1}"].Text = GetString("Description");
        column = column.NextColumn();

            case "ComponentId":
              mp.ComponentId = ws[$"{crtCol}{row}"].Text;
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
            case "Description":
              mp.Description = ws[$"{crtCol}{row}"].Text;
              break;

            this.ComponentId = mp.ComponentId;
            this.ModuleId = mp.ModuleId;
            this.ComponentName = mp.ComponentName;
            this.LatestVersion = mp.LatestVersion;
            this.Description = mp.Description;


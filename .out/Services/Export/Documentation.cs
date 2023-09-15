
        ws[$"{column}{row}"].SetValue(input.DocumentationId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ModuleId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FullName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Contents);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsCurrentVersion, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.CreatedByUserDisplayName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.CreatedByUserEmail);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.LastModifiedByUserDisplayName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.LastModifiedByUserEmail);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "DocumentationId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("DocumentationId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ModuleId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ModuleId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FullName";
        ws[$"{column}{row + 1}"].Text = GetString("FullName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Contents";
        ws[$"{column}{row + 1}"].Text = GetString("Contents");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsCurrentVersion;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsCurrentVersion") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "CreatedByUserDisplayName";
        ws[$"{column}{row + 1}"].Text = GetString("CreatedByUserDisplayName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "CreatedByUserEmail";
        ws[$"{column}{row + 1}"].Text = GetString("CreatedByUserEmail");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "LastModifiedByUserDisplayName";
        ws[$"{column}{row + 1}"].Text = GetString("LastModifiedByUserDisplayName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "LastModifiedByUserEmail";
        ws[$"{column}{row + 1}"].Text = GetString("LastModifiedByUserEmail");
        column = column.NextColumn();

            case "DocumentationId":
              mp.DocumentationId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ModuleId":
              mp.ModuleId = ws[$"{crtCol}{row}"].Text;
              break;
            case "FullName":
              mp.FullName = ws[$"{crtCol}{row}"].Text;
              break;
            case "Contents":
              mp.Contents = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsCurrentVersion":
              mp.IsCurrentVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "CreatedByUserDisplayName":
              mp.CreatedByUserDisplayName = ws[$"{crtCol}{row}"].Text;
              break;
            case "CreatedByUserEmail":
              mp.CreatedByUserEmail = ws[$"{crtCol}{row}"].Text;
              break;
            case "LastModifiedByUserDisplayName":
              mp.LastModifiedByUserDisplayName = ws[$"{crtCol}{row}"].Text;
              break;
            case "LastModifiedByUserEmail":
              mp.LastModifiedByUserEmail = ws[$"{crtCol}{row}"].Text;
              break;

            this.DocumentationId = mp.DocumentationId;
            this.ModuleId = mp.ModuleId;
            this.FullName = mp.FullName;
            this.Contents = mp.Contents;
            this.IsCurrentVersion = mp.IsCurrentVersion;
            this.CreatedByUserDisplayName = mp.CreatedByUserDisplayName;
            this.CreatedByUserEmail = mp.CreatedByUserEmail;
            this.LastModifiedByUserDisplayName = mp.LastModifiedByUserDisplayName;
            this.LastModifiedByUserEmail = mp.LastModifiedByUserEmail;


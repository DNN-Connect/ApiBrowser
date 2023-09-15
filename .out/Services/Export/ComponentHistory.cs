
        ws[$"{column}{row}"].SetValue(input.ComponentHistoryId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ComponentId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Version);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.VersionNormalized);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FullName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.CodeLines, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.CommentLines, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.EmptyLines, userUnits["um"]);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "ComponentHistoryId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ComponentHistoryId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ComponentId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ComponentId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Version";
        ws[$"{column}{row + 1}"].Text = GetString("Version");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "VersionNormalized";
        ws[$"{column}{row + 1}"].Text = GetString("VersionNormalized");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FullName";
        ws[$"{column}{row + 1}"].Text = GetString("FullName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "CodeLines;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("CodeLines") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "CommentLines;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("CommentLines") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "EmptyLines;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("EmptyLines") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();

            case "ComponentHistoryId":
              mp.ComponentHistoryId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ComponentId":
              mp.ComponentId = ws[$"{crtCol}{row}"].Text;
              break;
            case "Version":
              mp.Version = ws[$"{crtCol}{row}"].Text;
              break;
            case "VersionNormalized":
              mp.VersionNormalized = ws[$"{crtCol}{row}"].Text;
              break;
            case "FullName":
              mp.FullName = ws[$"{crtCol}{row}"].Text;
              break;
            case "CodeLines":
              mp.CodeLines = ws[$"{crtCol}{row}"].Text;
              break;
            case "CommentLines":
              mp.CommentLines = ws[$"{crtCol}{row}"].Text;
              break;
            case "EmptyLines":
              mp.EmptyLines = ws[$"{crtCol}{row}"].Text;
              break;

            this.ComponentHistoryId = mp.ComponentHistoryId;
            this.ComponentId = mp.ComponentId;
            this.Version = mp.Version;
            this.VersionNormalized = mp.VersionNormalized;
            this.FullName = mp.FullName;
            this.CodeLines = mp.CodeLines;
            this.CommentLines = mp.CommentLines;
            this.EmptyLines = mp.EmptyLines;


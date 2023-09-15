
        ws[$"{column}{row}"].SetValue(input.CodeBlockId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.MemberId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Version);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.CodeHash);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.StartLine, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.StartColumn, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.EndLine, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.EndColumn, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FileName);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "CodeBlockId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("CodeBlockId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "MemberId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("MemberId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Version";
        ws[$"{column}{row + 1}"].Text = GetString("Version");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "CodeHash";
        ws[$"{column}{row + 1}"].Text = GetString("CodeHash");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "StartLine;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("StartLine") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "StartColumn;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("StartColumn") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "EndLine;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("EndLine") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "EndColumn;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("EndColumn") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FileName";
        ws[$"{column}{row + 1}"].Text = GetString("FileName");
        column = column.NextColumn();

            case "CodeBlockId":
              mp.CodeBlockId = ws[$"{crtCol}{row}"].Text;
              break;
            case "MemberId":
              mp.MemberId = ws[$"{crtCol}{row}"].Text;
              break;
            case "Version":
              mp.Version = ws[$"{crtCol}{row}"].Text;
              break;
            case "CodeHash":
              mp.CodeHash = ws[$"{crtCol}{row}"].Text;
              break;
            case "StartLine":
              mp.StartLine = ws[$"{crtCol}{row}"].Text;
              break;
            case "StartColumn":
              mp.StartColumn = ws[$"{crtCol}{row}"].Text;
              break;
            case "EndLine":
              mp.EndLine = ws[$"{crtCol}{row}"].Text;
              break;
            case "EndColumn":
              mp.EndColumn = ws[$"{crtCol}{row}"].Text;
              break;
            case "FileName":
              mp.FileName = ws[$"{crtCol}{row}"].Text;
              break;

            this.CodeBlockId = mp.CodeBlockId;
            this.MemberId = mp.MemberId;
            this.Version = mp.Version;
            this.CodeHash = mp.CodeHash;
            this.StartLine = mp.StartLine;
            this.StartColumn = mp.StartColumn;
            this.EndLine = mp.EndLine;
            this.EndColumn = mp.EndColumn;
            this.FileName = mp.FileName;



        ws[$"{column}{row}"].SetValue(input.NamespaceId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ParentId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ModuleId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.NamespaceName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.LastQualifier);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Description);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "NamespaceId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("NamespaceId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ParentId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ParentId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ModuleId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ModuleId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "NamespaceName";
        ws[$"{column}{row + 1}"].Text = GetString("NamespaceName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "LastQualifier";
        ws[$"{column}{row + 1}"].Text = GetString("LastQualifier");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Description";
        ws[$"{column}{row + 1}"].Text = GetString("Description");
        column = column.NextColumn();

            case "NamespaceId":
              mp.NamespaceId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ParentId":
              mp.ParentId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ModuleId":
              mp.ModuleId = ws[$"{crtCol}{row}"].Text;
              break;
            case "NamespaceName":
              mp.NamespaceName = ws[$"{crtCol}{row}"].Text;
              break;
            case "LastQualifier":
              mp.LastQualifier = ws[$"{crtCol}{row}"].Text;
              break;
            case "Description":
              mp.Description = ws[$"{crtCol}{row}"].Text;
              break;

            this.NamespaceId = mp.NamespaceId;
            this.ParentId = mp.ParentId;
            this.ModuleId = mp.ModuleId;
            this.NamespaceName = mp.NamespaceName;
            this.LastQualifier = mp.LastQualifier;
            this.Description = mp.Description;


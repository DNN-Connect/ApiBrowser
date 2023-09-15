
        ws[$"{column}{row}"].SetValue(input.ModuleId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.NamespaceId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ClassId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.MemberId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.MainType, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.SubType, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Name);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Description);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.PendingDescription);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.IsDeprecated, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.DeprecatedInVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.DisappearedInVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.LastModifiedByUserID, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.LastModifiedOnDate, userUnits["um"]);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "ModuleId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ModuleId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "NamespaceId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("NamespaceId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ClassId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ClassId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "MemberId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("MemberId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "MainType;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("MainType") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "SubType;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("SubType") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Name";
        ws[$"{column}{row + 1}"].Text = GetString("Name");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Description";
        ws[$"{column}{row + 1}"].Text = GetString("Description");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "PendingDescription";
        ws[$"{column}{row + 1}"].Text = GetString("PendingDescription");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "IsDeprecated;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("IsDeprecated") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "DeprecatedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("DeprecatedInVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "DisappearedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("DisappearedInVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "LastModifiedByUserID;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("LastModifiedByUserID") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "LastModifiedOnDate;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("LastModifiedOnDate") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();

            case "ModuleId":
              mp.ModuleId = ws[$"{crtCol}{row}"].Text;
              break;
            case "NamespaceId":
              mp.NamespaceId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ClassId":
              mp.ClassId = ws[$"{crtCol}{row}"].Text;
              break;
            case "MemberId":
              mp.MemberId = ws[$"{crtCol}{row}"].Text;
              break;
            case "MainType":
              mp.MainType = ws[$"{crtCol}{row}"].Text;
              break;
            case "SubType":
              mp.SubType = ws[$"{crtCol}{row}"].Text;
              break;
            case "Name":
              mp.Name = ws[$"{crtCol}{row}"].Text;
              break;
            case "Description":
              mp.Description = ws[$"{crtCol}{row}"].Text;
              break;
            case "PendingDescription":
              mp.PendingDescription = ws[$"{crtCol}{row}"].Text;
              break;
            case "IsDeprecated":
              mp.IsDeprecated = ws[$"{crtCol}{row}"].Text;
              break;
            case "DeprecatedInVersion":
              mp.DeprecatedInVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "DisappearedInVersion":
              mp.DisappearedInVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "LastModifiedByUserID":
              mp.LastModifiedByUserID = ws[$"{crtCol}{row}"].Text;
              break;
            case "LastModifiedOnDate":
              mp.LastModifiedOnDate = ws[$"{crtCol}{row}"].Text;
              break;

            this.ModuleId = mp.ModuleId;
            this.NamespaceId = mp.NamespaceId;
            this.ClassId = mp.ClassId;
            this.MemberId = mp.MemberId;
            this.MainType = mp.MainType;
            this.SubType = mp.SubType;
            this.Name = mp.Name;
            this.Description = mp.Description;
            this.PendingDescription = mp.PendingDescription;
            this.IsDeprecated = mp.IsDeprecated;
            this.DeprecatedInVersion = mp.DeprecatedInVersion;
            this.DisappearedInVersion = mp.DisappearedInVersion;
            this.LastModifiedByUserID = mp.LastModifiedByUserID;
            this.LastModifiedOnDate = mp.LastModifiedOnDate;


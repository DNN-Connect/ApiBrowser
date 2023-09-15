
        ws[$"{column}{row}"].SetValue(input.CommentID, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ComponentId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ItemType, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ItemId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ParentId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Message);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Approved, userUnits["um"]);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "CommentID;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("CommentID") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ComponentId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ComponentId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ItemType;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ItemType") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ItemId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ItemId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ParentId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ParentId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Message";
        ws[$"{column}{row + 1}"].Text = GetString("Message");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Approved;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("Approved") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();

            case "CommentID":
              mp.CommentID = ws[$"{crtCol}{row}"].Text;
              break;
            case "ComponentId":
              mp.ComponentId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ItemType":
              mp.ItemType = ws[$"{crtCol}{row}"].Text;
              break;
            case "ItemId":
              mp.ItemId = ws[$"{crtCol}{row}"].Text;
              break;
            case "ParentId":
              mp.ParentId = ws[$"{crtCol}{row}"].Text;
              break;
            case "Message":
              mp.Message = ws[$"{crtCol}{row}"].Text;
              break;
            case "Approved":
              mp.Approved = ws[$"{crtCol}{row}"].Text;
              break;

            this.CommentID = mp.CommentID;
            this.ComponentId = mp.ComponentId;
            this.ItemType = mp.ItemType;
            this.ItemId = mp.ItemId;
            this.ParentId = mp.ParentId;
            this.Message = mp.Message;
            this.Approved = mp.Approved;


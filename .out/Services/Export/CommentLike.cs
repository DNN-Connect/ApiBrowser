
        ws[$"{column}{row}"].SetValue(input.CommentId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.UserId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Datime, userUnits["um"]);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "CommentId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("CommentId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "UserId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("UserId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Datime;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("Datime") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();

            case "CommentId":
              mp.CommentId = ws[$"{crtCol}{row}"].Text;
              break;
            case "UserId":
              mp.UserId = ws[$"{crtCol}{row}"].Text;
              break;
            case "Datime":
              mp.Datime = ws[$"{crtCol}{row}"].Text;
              break;

            this.CommentId = mp.CommentId;
            this.UserId = mp.UserId;
            this.Datime = mp.Datime;


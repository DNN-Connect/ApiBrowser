
        ws[$"{column}{row}"].SetValue(input.ReferenceId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.CodeBlockId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FullName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.Offset, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ReferencedMemberId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefMemberId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefStartLine, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefEndLine, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefMemberName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefFullName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefAppearedInVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefDeprecatedInVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefDisappearedInVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefClassId, userUnits["um"]);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefClassName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.FromRefFullQualifier);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ToRefMemberName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ToRefFullName);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ToRefAppearedInVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ToRefDeprecatedInVersion);
        column = column.NextColumn();
        ws[$"{column}{row}"].SetValue(input.ToRefDisappearedInVersion);
        column = column.NextColumn();

        ws[$"{column}{row}"].Text = "ReferenceId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ReferenceId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "CodeBlockId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("CodeBlockId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FullName";
        ws[$"{column}{row + 1}"].Text = GetString("FullName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "Offset;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("Offset") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ReferencedMemberId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("ReferencedMemberId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefMemberId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("FromRefMemberId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefStartLine;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("FromRefStartLine") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefEndLine;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("FromRefEndLine") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefMemberName";
        ws[$"{column}{row + 1}"].Text = GetString("FromRefMemberName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefFullName";
        ws[$"{column}{row + 1}"].Text = GetString("FromRefFullName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefAppearedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("FromRefAppearedInVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefDeprecatedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("FromRefDeprecatedInVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefDisappearedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("FromRefDisappearedInVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefClassId;" + userUnits["um"].Suffix;
        ws[$"{column}{row + 1}"].Text = GetString("FromRefClassId") + " (" + userUnits["um"].Suffix + ")";
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefClassName";
        ws[$"{column}{row + 1}"].Text = GetString("FromRefClassName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "FromRefFullQualifier";
        ws[$"{column}{row + 1}"].Text = GetString("FromRefFullQualifier");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ToRefMemberName";
        ws[$"{column}{row + 1}"].Text = GetString("ToRefMemberName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ToRefFullName";
        ws[$"{column}{row + 1}"].Text = GetString("ToRefFullName");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ToRefAppearedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("ToRefAppearedInVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ToRefDeprecatedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("ToRefDeprecatedInVersion");
        column = column.NextColumn();
        ws[$"{column}{row}"].Text = "ToRefDisappearedInVersion";
        ws[$"{column}{row + 1}"].Text = GetString("ToRefDisappearedInVersion");
        column = column.NextColumn();

            case "ReferenceId":
              mp.ReferenceId = ws[$"{crtCol}{row}"].Text;
              break;
            case "CodeBlockId":
              mp.CodeBlockId = ws[$"{crtCol}{row}"].Text;
              break;
            case "FullName":
              mp.FullName = ws[$"{crtCol}{row}"].Text;
              break;
            case "Offset":
              mp.Offset = ws[$"{crtCol}{row}"].Text;
              break;
            case "ReferencedMemberId":
              mp.ReferencedMemberId = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefMemberId":
              mp.FromRefMemberId = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefStartLine":
              mp.FromRefStartLine = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefEndLine":
              mp.FromRefEndLine = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefMemberName":
              mp.FromRefMemberName = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefFullName":
              mp.FromRefFullName = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefAppearedInVersion":
              mp.FromRefAppearedInVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefDeprecatedInVersion":
              mp.FromRefDeprecatedInVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefDisappearedInVersion":
              mp.FromRefDisappearedInVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefClassId":
              mp.FromRefClassId = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefClassName":
              mp.FromRefClassName = ws[$"{crtCol}{row}"].Text;
              break;
            case "FromRefFullQualifier":
              mp.FromRefFullQualifier = ws[$"{crtCol}{row}"].Text;
              break;
            case "ToRefMemberName":
              mp.ToRefMemberName = ws[$"{crtCol}{row}"].Text;
              break;
            case "ToRefFullName":
              mp.ToRefFullName = ws[$"{crtCol}{row}"].Text;
              break;
            case "ToRefAppearedInVersion":
              mp.ToRefAppearedInVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "ToRefDeprecatedInVersion":
              mp.ToRefDeprecatedInVersion = ws[$"{crtCol}{row}"].Text;
              break;
            case "ToRefDisappearedInVersion":
              mp.ToRefDisappearedInVersion = ws[$"{crtCol}{row}"].Text;
              break;

            this.ReferenceId = mp.ReferenceId;
            this.CodeBlockId = mp.CodeBlockId;
            this.FullName = mp.FullName;
            this.Offset = mp.Offset;
            this.ReferencedMemberId = mp.ReferencedMemberId;
            this.FromRefMemberId = mp.FromRefMemberId;
            this.FromRefStartLine = mp.FromRefStartLine;
            this.FromRefEndLine = mp.FromRefEndLine;
            this.FromRefMemberName = mp.FromRefMemberName;
            this.FromRefFullName = mp.FromRefFullName;
            this.FromRefAppearedInVersion = mp.FromRefAppearedInVersion;
            this.FromRefDeprecatedInVersion = mp.FromRefDeprecatedInVersion;
            this.FromRefDisappearedInVersion = mp.FromRefDisappearedInVersion;
            this.FromRefClassId = mp.FromRefClassId;
            this.FromRefClassName = mp.FromRefClassName;
            this.FromRefFullQualifier = mp.FromRefFullQualifier;
            this.ToRefMemberName = mp.ToRefMemberName;
            this.ToRefFullName = mp.ToRefFullName;
            this.ToRefAppearedInVersion = mp.ToRefAppearedInVersion;
            this.ToRefDeprecatedInVersion = mp.ToRefDeprecatedInVersion;
            this.ToRefDisappearedInVersion = mp.ToRefDisappearedInVersion;


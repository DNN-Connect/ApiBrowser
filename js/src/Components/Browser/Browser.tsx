import * as React from "react";
import * as Models from "../../Models/";
import ClassDetails from "./ClassDetails";
import MemberDetails from "./MemberDetails";
import NamespaceDetails from "./NamespaceDetails";
import BrowserNavBar from "./BrowserNavBar";

interface IBrowserProps {
  module: Models.IAppModule;
  selection: Models.IViewSelection;
  classes: Models.IApiClass[];
  documentationLink: string;
}

interface IBrowserState {
  selectedClass: Models.IApiClass | null;
  selectedMember: Models.IMember | null;
  selectedMemberCodeblocks: Models.IMemberCodeBlock[];
  classes: Models.IApiClass[];
}

export default class Browser extends React.Component<
  IBrowserProps,
  IBrowserState
> {
  constructor(props: IBrowserProps) {
    super(props);
    this.state = {
      selectedClass: props.selection.SelectedClass,
      selectedMember: props.selection.SelectedMember,
      selectedMemberCodeblocks: [],
      classes: props.classes
    };
  }

  componentDidMount() {
    this.loadAllClasses();
    window.onpopstate = function(e) {
      location.reload();
    };
    if (this.state.selectedMember != null) {
      this.props.module.service.getMemberCodeBlocks(
        this.state.selectedMember.MemberId,
        (data: Models.IMemberCodeBlock[]) => {
          this.setState({
            selectedMemberCodeblocks: data
          });
        }
      );
    }
  }

  private loadAllClasses(): void {
    this.props.classes.forEach(c => {
      this.checkClass(c);
    });
  }

  private checkClass(classToCheck: Models.IApiClass): void {
    if (classToCheck.Members == undefined) {
      this.props.module.service.getMembers(
        classToCheck.ClassId,
        (data: Models.IMember[]) => {
          var c = classToCheck;
          c.Members = data;
          var classList = this.state.classes.map(cl => {
            return cl.ClassId == c.ClassId ? c : cl;
          });
          this.setState(
            {
              classes: classList
            },
            () => {
              if (
                this.state.selectedClass &&
                this.state.selectedClass.ClassId == classToCheck.ClassId
              ) {
                this.setState({
                  selectedClass: c
                });
              }
            }
          );
        }
      );
    }
  }

  private getUrl(): string {
    var url = [location.protocol, "//", location.host, location.pathname].join(
      ""
    );
    url += "?view=" + this.props.selection.SelectedNamespace.NamespaceName;
    url +=
      this.state.selectedClass == null
        ? ""
        : "." + this.state.selectedClass.ClassName;
    url +=
      this.state.selectedMember == null
        ? ""
        : "." + this.state.selectedMember.MemberName;
    return url;
  }

  private changeUrl(newUrl: string): void {
    window.history.pushState(null, document.title, newUrl);
  }

  private changeSelection(
    newClass: Models.IApiClass | null,
    newMember: Models.IMember | null
  ): void {
    var codeblocks = this.state.selectedMemberCodeblocks;
    if (newMember == null && this.state.selectedMember != null) {
      codeblocks = [];
    } else if (newMember != null) {
      if (
        this.state.selectedMember == null ||
        this.state.selectedMember.MemberId != newMember.MemberId
      ) {
        codeblocks = [];
        this.props.module.service.getMemberCodeBlocks(
          newMember.MemberId,
          (data: Models.IMemberCodeBlock[]) => {
            this.setState({
              selectedMemberCodeblocks: data
            });
          }
        );
      }
    }
    this.setState(
      {
        selectedClass: newClass,
        selectedMember: newMember,
        selectedMemberCodeblocks: codeblocks
      },
      () => {
        this.changeUrl(this.getUrl());
      }
    );
  }

  private editMemberDescription(
    memberId: number,
    newDescription: string
  ): void {
    this.props.module.service.saveMemberDescription(
      memberId,
      newDescription,
      (member: Models.IMember) => {
        var apiClass = this.state.selectedClass;
        var newClassList = this.state.classes.map(c => {
          if (c.ClassId == member.ClassId) {
            var newMembers = (c.Members as Models.IMember[]).map(m => {
              return m.MemberId == member.MemberId ? member : m;
            });
            c.Members = newMembers;
            apiClass = c;
          }
          return c;
        });
        this.setState({
          selectedClass: apiClass,
          classes: newClassList
        });
      }
    );
  }
  private editClassDescription(classId: number, newDescription: string): void {
    this.props.module.service.saveClassDescription(
      classId,
      newDescription,
      (apiClass: Models.IApiClass) => {
        var newClassList = this.state.classes.map(c => {
          return c.ClassId == classId ? apiClass : c;
        });
        this.setState({
          selectedClass: apiClass,
          classes: newClassList
        });
      }
    );
  }

  public render(): JSX.Element {
    var mainScreen =
      this.state.selectedClass == null ? (
        <NamespaceDetails
          module={this.props.module}
          namespace={this.props.selection.SelectedNamespace}
          classes={this.state.classes}
          changeSelection={(a, b) => this.changeSelection(a, b)}
        />
      ) : this.state.selectedMember == null ? (
        <ClassDetails
          module={this.props.module}
          apiclass={this.state.selectedClass}
          changeSelection={(a, b) => this.changeSelection(a, b)}
          documentationLink={this.props.documentationLink}
          updateDescription={(a, b) => this.editClassDescription(a, b)}
        />
      ) : (
        <MemberDetails
          module={this.props.module}
          classes={this.state.classes}
          member={this.state.selectedMember}
          apiclass={this.state.selectedClass}
          changeSelection={(a, b) => this.changeSelection(a, b)}
          codeblocks={this.state.selectedMemberCodeblocks}
          documentationLink={this.props.documentationLink}
          updateDescription={(a, b) => this.editMemberDescription(a, b)}
        />
      );
    var selectedKeys: string[] = [];
    if (this.state.selectedClass != null) {
      if (this.state.selectedMember != null) {
        selectedKeys.push("m-" + this.state.selectedMember.MemberId.toString());
      } else {
        selectedKeys.push("c-" + this.state.selectedClass.ClassId.toString());
      }
    }
    return (
      <div>
        <div className="toc-wrapper">
          <a
            href="#"
            className={"toc-h1 toc-link" + (this.state.selectedClass == null ? " active" : "")}
            onClick={e => {
              e.preventDefault();
              this.changeSelection(null, null);
            }}
          >
            {this.props.selection.SelectedNamespace.NamespaceName}
          </a>
          <BrowserNavBar
            module={this.props.module}
            namespace={this.props.selection.SelectedNamespace}
            classes={this.state.classes}
            selectedClassId={this.state.selectedClass == null ? -1 : this.state.selectedClass.ClassId}
            selectedMemberId={this.state.selectedMember == null ? -1 : this.state.selectedMember.MemberId}
            changeSelection={(c, m) => this.changeSelection(c, m)}
          />
        </div>
        <div className="page-wrapper">
          <div className="dark-box" />
          {mainScreen}
        </div>
      </div>
    );
  }
}

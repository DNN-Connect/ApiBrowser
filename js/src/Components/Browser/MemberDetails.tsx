import * as React from "react";
import * as Models from "../../Models/";
import EditableText from "../Generic/EditableText";
import * as ReactMarkdown from "react-markdown";

interface IMemberDetailsProps {
  module: Models.IAppModule;
  member: Models.IMember;
  changeSelection: (
    newClass: Models.IApiClass | null,
    newMember: Models.IMember | null
  ) => void;
  apiclass: Models.IApiClass;
  codeblocks: Models.IMemberCodeBlock[];
  documentationLink: string;
  updateDescription: (id: number, description: string) => void;
}
interface IMemberDetailsState {
  incomingReferences: Models.IReference[];
  outgoingReferences: Models.IReference[];
  currentCodeblock: Models.ICodeBlock | null;
}

declare var hljs: any;

export default class MemberDetails extends React.Component<
  IMemberDetailsProps,
  IMemberDetailsState
> {
  refs: {
    codeblock: HTMLPreElement;
    declaration: HTMLElement;
  };
  constructor(props: IMemberDetailsProps) {
    super(props);
    this.state = {
      incomingReferences: [],
      outgoingReferences: [],
      currentCodeblock: null
    };
  }
  componentDidMount() {
    this.loadReferences(this.props.member.MemberId);
  }

  componentWillReceiveProps(nextProps: IMemberDetailsProps) {
    if (nextProps.member.MemberId != this.props.member.MemberId) {
      this.setState({
        incomingReferences: [],
        outgoingReferences: [],
        currentCodeblock: null
      });
      this.loadReferences(nextProps.member.MemberId);
    }
    console.log(window.location);
  }
  private loadReferences(memberId: number) {
    this.setState(
      {
        incomingReferences: [],
        outgoingReferences: []
      },
      () => {
        this.props.module.service.getReferencesToMember(
          memberId,
          (data: Models.IReference[]) => {
            this.setState({
              incomingReferences: data
            });
          }
        );
      }
    );
  }

  componentDidUpdate(prevProps: IMemberDetailsProps) {
    hljs.highlightBlock(this.refs.declaration);
  }
  private showCodeBlock(codeblockId: number): void {
    this.props.module.service.getCodeblock(
      codeblockId,
      (data: Models.ICodeBlock) => {
        this.setState(
          {
            currentCodeblock: data
          },
          () => {
            hljs.highlightBlock(this.refs.codeblock);
          }
        );
      }
    );
  }
  public render(): JSX.Element {
    var memType = "";
    switch (this.props.member.MemberType) {
      case 0:
        memType = "Constructor";
        break;
      case 1:
        memType = "Method";
        break;
      case 2:
        memType = "Field";
        break;
      case 3:
        memType = "Property";
        break;
      case 4:
        memType = "Event";
        break;
    }
    var props = [];
    if (this.props.member.DeprecatedInVersion) {
      props.push(
        <dt key={1} className="red">
          {this.props.module.resources.DeprecatedIn}:
        </dt>
      );
      props.push(
        <dd key={2} className="red">
          {this.props.apiclass.DeprecatedInVersion}
        </dd>
      );
    }
    if (this.props.member.DisappearedInVersion) {
      props.push(
        <dt key={3} className="red">
          {this.props.module.resources.DisappearedIn}:
        </dt>
      );
      props.push(
        <dd key={4} className="red">
          {this.props.member.DisappearedInVersion}
        </dd>
      );
    }
    var deprecation =
      this.props.member.DeprecationMessage == undefined ? (
        this.props.apiclass.DeprecationMessage == undefined ? null : (
          <div className="alert alert-danger">
            {this.props.apiclass.DeprecationMessage}
          </div>
        )
      ) : (
        <div className="alert alert-danger">
          {this.props.member.DeprecationMessage}
        </div>
      );
    var cbrows = this.props.codeblocks.map(cb => {
      return (
        <tr key={cb.CodeBlockId}>
          <td>{cb.Version}</td>
          <td>{cb.FileName}</td>
          <td>
            {cb.StartLine} - {cb.EndLine}
          </td>
          <td style={{ width: "32px" }}>
            <a
              href="#"
              className="btn btn-sm btn-default"
              onClick={e => {
                e.preventDefault();
                this.showCodeBlock(cb.CodeBlockId);
              }}
            >
              <i className="glyphicon glyphicon-eye-open" />
            </a>
          </td>
        </tr>
      );
    });
    var documentation = this.props.member.DocumentationContents ? (
      <ReactMarkdown source={this.props.member.DocumentationContents} />
    ) : null;
    var editurl = "name=" + this.props.member.FullQualifier;
    var docedit = this.props.module.security.CanComment ? (
      <a
        href={this.props.documentationLink + "?" + editurl}
        className="btn btn-sm btn-default"
      >
        <i className="glyphicon glyphicon-pencil" />
      </a>
    ) : null;
    var refs =
      this.state.incomingReferences.length > 0 ? (
        <div>
          <h4>References</h4>
          <table>
            <tbody>
              {this.state.incomingReferences.map(r => {
                return (
                  <tr key={r.ReferenceId}>
                    <td>
                      <a
                        href={
                          window.location.pathname +
                          "?view=" +
                          r.FromRefFullQualifier
                        }
                      >
                        {r.FromRefClassName}::{r.FromRefMemberName}
                      </a>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      ) : null;
    var codeblock = this.state.currentCodeblock ? (
      <pre ref="codeblock">
        <code className="cs" ref="codeblock">
          {this.state.currentCodeblock.Body}
        </code>
      </pre>
    ) : null;
    return (
      <div className="content">
        <h2>
          {this.props.member.ClassName}.{this.props.member.MemberName} {memType}
        </h2>
        {deprecation}
        <dl className="dl-horizontal">
          <dt>Class:</dt>
          <dd>
            <a
              href="#"
              onClick={e => {
                e.preventDefault();
                this.props.changeSelection(this.props.apiclass, null);
              }}
            >
              {this.props.member.ClassName}
            </a>
          </dd>
          <dt>Namespace:</dt>
          <dd>
            <a
              href="#"
              onClick={e => {
                e.preventDefault();
                this.props.changeSelection(null, null);
              }}
            >
              {this.props.member.NamespaceName}
            </a>
          </dd>
          <dt>Assembly:</dt>
          <dd>{this.props.member.ComponentName}</dd>
          <dt>{this.props.module.resources.FirstDetected}:</dt>
          <dd>{this.props.member.AppearedInVersion}</dd>
          {props}
          <dt>{this.props.module.resources.Codeblocks}:</dt>
          <dd>{this.props.member.CodeBlockCount}</dd>
        </dl>
        <h4>{this.props.module.resources.Description}</h4>
        <EditableText
          module={this.props.module}
          element={this.props.member as Models.IClassOrMember}
          update={description =>
            this.props.updateDescription(
              this.props.member.MemberId,
              description
            )
          }
        />
        <h4>{this.props.module.resources.Declaration}</h4>
        <pre>
          <code className="cs" ref="declaration">
            {this.props.member.Declaration}
          </code>
        </pre>
        <h4>{this.props.module.resources.Codeblocks}</h4>
        {codeblock}
        <table>
          <thead>
            <tr>
              <th>{this.props.module.resources.Version}</th>
              <th>{this.props.module.resources.File}</th>
              <th>{this.props.module.resources.Lines}</th>
              <th />
            </tr>
          </thead>
          <tbody>{cbrows}</tbody>
        </table>
        {refs}
        <h4>
          {this.props.module.resources.Documentation} {docedit}
        </h4>
        {documentation}
      </div>
    );
  }
}

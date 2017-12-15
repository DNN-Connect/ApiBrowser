import * as React from 'react';
import * as Models from '../../Models/';
import CodeBlock from './CodeBlock';

interface IMemberDetailsProps {
    module: Models.IAppModule;
    member: Models.IMember;
    changeSelection: (newClass: Models.IApiClass | null, newMember: Models.IMember | null) => void;
    apiclass: Models.IApiClass;
    codeblocks: Models.IMemberCodeBlock[];
};

declare var hljs: any;

export default class MemberDetails extends React.Component<IMemberDetailsProps> {
    refs: {
        codeblock: CodeBlock;
        declaration: HTMLElement;
    }
    componentDidUpdate(prevProps: IMemberDetailsProps) {
        hljs.highlightBlock(this.refs.declaration);
    }
    private showCodeBlock(codeblockId: number): void {
        this.refs.codeblock.show(codeblockId);
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
            props.push(<dt className="red">Deprecated in:</dt>);
            props.push(<dd className="red">{this.props.apiclass.DeprecatedInVersion}</dd>);
        }
        if (this.props.member.DisappearedInVersion) {
            props.push(<dt className="red">Disappeared in:</dt>);
            props.push(<dd className="red">{this.props.member.DisappearedInVersion}</dd>);
        }
        var deprecation = this.props.member.DeprecationMessage == undefined ? this.props.apiclass.DeprecationMessage == undefined ? null : (
            <div className="alert alert-danger">{this.props.apiclass.DeprecationMessage}</div>
        ) : (
                <div className="alert alert-danger">{this.props.member.DeprecationMessage}</div>
            );
        var cbrows = this.props.codeblocks.map(cb => {
            return (
                <tr key={cb.CodeBlockId}>
                    <td>{cb.Version}</td>
                    <td>{cb.FileName}</td>
                    <td>{cb.StartLine} - {cb.EndLine}</td>
                    <td style={{ width: "32px" }}>
                        <a href="#" className="btn btn-sm btn-default"
                            onClick={e => { e.preventDefault(); this.showCodeBlock(cb.CodeBlockId) }}><i className="glyphicon glyphicon-eye-open"></i></a>
                    </td>
                </tr>
            );
        });
        return (
            <div>
                <h2>{this.props.member.ClassName}.{this.props.member.MemberName} {memType}</h2>
                {deprecation}
                <dl className="dl-horizontal">
                    <dt>Class:</dt>
                    <dd>
                        <a href="#" onClick={e => { e.preventDefault(); this.props.changeSelection(this.props.apiclass, null) }}>{this.props.member.ClassName}</a>
                    </dd>
                    <dt>Namespace:</dt>
                    <dd>
                        <a href="#" onClick={e => { e.preventDefault(); this.props.changeSelection(null, null) }}>{this.props.member.NamespaceName}</a>
                    </dd>
                    <dt>Assembly:</dt>
                    <dd>
                        {this.props.member.ComponentName}
                    </dd>
                    <dt>First detected:</dt>
                    <dd>
                        {this.props.member.AppearedInVersion}
                    </dd>
                    {props}
                    <dt>Codeblocks:</dt>
                    <dd>
                        {this.props.member.CodeBlockCount}
                    </dd>
                </dl>
                <h4>Declaration</h4>
                <pre><code className="cs" ref="declaration">{this.props.member.Declaration}</code></pre>
                <h4>Codeblocks</h4>
                <table className="table">
                    <thead>
                        <tr>
                            <th>Version</th>
                            <th>File</th>
                            <th>Lines</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {cbrows}
                    </tbody>
                </table>
                <CodeBlock ref="codeblock" module={this.props.module} />
            </div>
        );
    }
}
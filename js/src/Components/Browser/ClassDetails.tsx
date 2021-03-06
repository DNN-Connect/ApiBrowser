import * as React from 'react';
import * as Models from '../../Models/';
import MemberList from './MemberList';
import EditableText from '../Generic/EditableText';
const ReactMarkdown = require('react-markdown');

interface IClassDetailsProps {
    module: Models.IAppModule;
    apiclass: Models.IApiClass;
    changeSelection: (newClass: Models.IApiClass | null, newMember: Models.IMember | null) => void;
    documentationLink: string;
    updateDescription: (id: number, description: string) => void;
};

declare var hljs: any;

export default class ClassDetails extends React.Component<IClassDetailsProps> {
    refs: {
        declaration: HTMLElement;
    }
    componentDidUpdate(prevProps: IClassDetailsProps) {
        hljs.highlightBlock(this.refs.declaration);
    }
    public render(): JSX.Element {
        var props = [];
        if (this.props.apiclass.DeprecatedInVersion) {
            props.push(<dt className="red">Deprecated in:</dt>);
            props.push(<dd className="red">{this.props.apiclass.DeprecatedInVersion}</dd>);
        }
        if (this.props.apiclass.DisappearedInVersion) {
            props.push(<dt className="red">Disappeared in:</dt>);
            props.push(<dd className="red">{this.props.apiclass.DisappearedInVersion}</dd>);
        }
        var deprecation = this.props.apiclass.DeprecationMessage == undefined ? null : (
            <div className="alert alert-danger">{this.props.apiclass.DeprecationMessage}</div>
        );
        var members = this.props.apiclass.Members ? (
            <MemberList module={this.props.module} members={this.props.apiclass.Members} changeSelection={(a, b) => this.props.changeSelection(this.props.apiclass, b)} />
        ) : null;
        var documentation = this.props.apiclass.DocumentationContents ? (
            <ReactMarkdown source={this.props.apiclass.DocumentationContents} />
        ) : null;
        var editurl = "name=" + this.props.apiclass.FullQualifier;
        var docedit = this.props.module.security.CanComment ? (
            <a href={this.props.documentationLink + "?" + editurl} className="btn btn-sm btn-default"><i className="glyphicon glyphicon-pencil"></i></a>
        ) : null;
        return (
            <div>
                <h2>{this.props.apiclass.ClassName} Class</h2>
                {deprecation}
                <dl className="dl-horizontal">
                    <dt>Namespace:</dt>
                    <dd>
                        <a href="#" onClick={e => { e.preventDefault(); this.props.changeSelection(null, null) }}>{this.props.apiclass.NamespaceName}</a>
                    </dd>
                    <dt>Assembly:</dt>
                    <dd>
                        {this.props.apiclass.ComponentName}
                    </dd>
                    <dt>{this.props.module.resources.FirstDetected}:</dt>
                    <dd>
                        {this.props.apiclass.AppearedInVersion}
                    </dd>
                    {props}
                </dl>
                <h4>{this.props.module.resources.Description}</h4>
                <EditableText module={this.props.module} element={this.props.apiclass as Models.IClassOrMember}
                    update={(description) => this.props.updateDescription(this.props.apiclass.ClassId, description)} />
                <h4>{this.props.module.resources.Declaration}</h4>
                <pre><code className="cs" ref="declaration">{this.props.apiclass.Declaration}</code></pre>
                {members}
                <h4>{this.props.module.resources.Documentation} {docedit}</h4>
                {documentation}
            </div>
        );
    }
}
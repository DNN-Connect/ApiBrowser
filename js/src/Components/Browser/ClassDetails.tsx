import * as React from 'react';
import * as Models from '../../Models/';
import MemberList from './MemberList';

interface IClassDetailsProps {
    module: Models.IAppModule;
    apiclass: Models.IApiClass;
    changeSelection: (newClass: Models.IApiClass | null, newMember: Models.IMember | null) => void;
};

export default class ClassDetails extends React.Component<IClassDetailsProps> {
    public render(): JSX.Element {
        var props = [];
        if (this.props.apiclass.DeprecatedInVersion) {
            props.push(<dt>Deprecated in:</dt>);
            props.push(<dd>{this.props.apiclass.DeprecatedInVersion}</dd>);
        }
        var members = this.props.apiclass.Members ? (
            <MemberList module={this.props.module} members={this.props.apiclass.Members} changeSelection={(a, b) => this.props.changeSelection(this.props.apiclass, b)} />
        ) : null;
        return (
            <div>
                <h2>{this.props.apiclass.ClassName} Class</h2>
                <dl className="dl-horizontal">
                    <dt>Namespace:</dt>
                    <dd>
                        <a href="#" onClick={e => { e.preventDefault(); this.props.changeSelection(null, null) }}>{this.props.apiclass.NamespaceName}</a>
                    </dd>
                    <dt>Assembly:</dt>
                    <dd>
                        {this.props.apiclass.ComponentName}
                    </dd>
                    <dt>First detected:</dt>
                    <dd>
                        {this.props.apiclass.AppearedInVersion}
                    </dd>
                </dl>
                <h4>Declaration</h4>
                <p>{this.props.apiclass.Declaration}</p>
                {members}
            </div>
        );
    }
}
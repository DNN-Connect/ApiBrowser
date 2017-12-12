import * as React from 'react';
import * as Models from '../../Models/';

interface IMemberDetailsProps {
    module: Models.IAppModule;
    member: Models.IMember;
    changeSelection: (newClass: Models.IApiClass | null, newMember: Models.IMember | null) => void;
    apiclass: Models.IApiClass;
};

export default class MemberDetails extends React.Component<IMemberDetailsProps> {
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
        return (
            <div>
                <h2>{this.props.member.ClassName}.{this.props.member.MemberName} {memType}</h2>
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
                </dl>

            </div>
        );
    }
}
import * as React from 'react';
import * as Models from '../../Models/';
import MemberSublist from './MemberSublist';

interface IMemberListProps {
    module: Models.IAppModule;
    members: Models.IMember[];
    changeSelection: (newClass: Models.IApiClass | null, newMember: Models.IMember | null) => void;
};

export default class MemberList extends React.Component<IMemberListProps> {
    public render(): JSX.Element {
        return (
            <div>
                <h4>{this.props.module.resources.Members}</h4>
                <MemberSublist module={this.props.module} title="Constructors" members={this.props.members} memberType={0} changeSelection={(a, b) => this.props.changeSelection(a, b)} />
                <MemberSublist module={this.props.module} title="Fields" members={this.props.members} memberType={2} changeSelection={(a, b) => this.props.changeSelection(a, b)} />
                <MemberSublist module={this.props.module} title="Properties" members={this.props.members} memberType={3} changeSelection={(a, b) => this.props.changeSelection(a, b)} />
                <MemberSublist module={this.props.module} title="Methods" members={this.props.members} memberType={1} changeSelection={(a, b) => this.props.changeSelection(a, b)} />
                <MemberSublist module={this.props.module} title="Events" members={this.props.members} memberType={4} changeSelection={(a, b) => this.props.changeSelection(a, b)} />
            </div>
        );
    }
}
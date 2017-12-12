import * as React from 'react';
import * as Models from '../../Models/';

interface IMemberSublistProps {
    module: Models.IAppModule;
    title: string;
    members: Models.IMember[];
    memberType: number;
    changeSelection: (newClass: Models.IApiClass | null, newMember: Models.IMember | null) => void;
};

export default class MemberSublist extends React.Component<IMemberSublistProps> {
    public render(): JSX.Element {
        var members = [];
        for (var i = 0; i < this.props.members.length; i++) {
            var m = this.props.members[i];
            if (m.MemberType == this.props.memberType) {
                members.push(m);
            }
        }
        if (members.length == 0) {
            return (<span></span>);
        }
        var rows = members.map(m => {
            return (
                <tr key={m.MemberId}>
                    <td>
                        <a href="#" onClick={e => { e.preventDefault(); this.props.changeSelection(null, m) }}>{m.MemberName}</a>
                    </td>
                    <td>{m.Description}</td>
                </tr>
            );
        });
        return (
            <div>
                <h6>{this.props.title}</h6>
                <table className="table">
                    <tbody>
                        {rows}
                    </tbody>
                </table>
            </div>
        );
    }
}
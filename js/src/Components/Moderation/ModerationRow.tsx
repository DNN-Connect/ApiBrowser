import * as React from 'react';
import * as Models from '../../Models/';
import * as moment from 'moment';

interface IModerationRowProps {
    module: Models.IAppModule;
    item: Models.IModerationItem;
    showItem: (item: Models.IModerationItem) => void;
};

export default class ModerationRow extends React.Component<IModerationRowProps> {
    public render(): JSX.Element {
        return (
            <tr>
                <td>{this.props.item.FullQualifier}</td>
                <td>{this.props.item.LastModifiedByUserDisplayName}</td>
                <td>{moment(this.props.item.LastModifiedOnDate).format('l')}</td>
                <td>{this.props.item.OldText ? this.props.item.OldText.substring(0, 30) + " ..." : ""}</td>
                <td>{this.props.item.NewText.substring(0, 30)} ...</td>
                <td style={{width: "24px"}}>
                    <a href="#" className="btn btn-sm btn-default"
                        onClick={e => { e.preventDefault(); this.props.showItem(this.props.item) }}>
                        <i className="glyphicon glyphicon-eye-open"></i>
                    </a>
                </td>
            </tr>
        );
    }
}
import * as React from 'react';
import * as Models from '../../Models/';

interface IDocumentationListProps {
    module: Models.IAppModule;
    list: Models.IDocumentation[];
    edit: (d: Models.IDocumentation) => void;
    copy: (d: Models.IDocumentation) => void;
    delete: (d: Models.IDocumentation) => void;
    setLastVersion: (d: Models.IDocumentation) => void;
};

export default class DocumentationList extends React.Component<IDocumentationListProps> {

    public render(): JSX.Element {
        var btncol = {
            width: "30px"
        }
        var rows = this.props.list.map(d => {
            var lastverbtn = this.props.module.security.CanModerate ? d.IsCurrentVersion ? null : (
                <a href="#" className="btn btn-default"
                    onClick={e => { e.preventDefault(); this.props.setLastVersion(d) }}>
                    <i className="glyphicon glyphicon-asterisk"></i></a>
            ) : null;
            var editbtn = this.props.module.security.CanModerate || d.CreatedByUserID == this.props.module.security.UserId ? (
                <a href="#" className="btn btn-default"
                    onClick={e => { e.preventDefault(); this.props.edit(d) }}>
                    <i className="glyphicon glyphicon-pencil"></i></a>
            ) : null;
            var copybtn = this.props.module.security.CanComment ? (
                <a href="#" className="btn btn-default"
                    onClick={e => { e.preventDefault(); this.props.copy(d) }}>
                    <i className="glyphicon glyphicon-repeat"></i></a>
            ) : null;
            var deletebtn = this.props.module.security.CanModerate || d.CreatedByUserID == this.props.module.security.UserId ? (
                <a href="#" className="btn btn-default"
                    onClick={e => { e.preventDefault(); this.props.delete(d) }}>
                    <i className="glyphicon glyphicon-remove"></i></a>
            ) : null;
            return (
                <tr>
                    <td>{d.DocumentationId}</td>
                    <td>{d.CreatedOnDate}</td>
                    <td>{d.CreatedByUserDisplayName}</td>
                    <td>{d.LastModifiedOnDate}</td>
                    <td>{d.LastModifiedByUserDisplayName}</td>
                    <td style={btncol}>{editbtn}</td>
                    <td style={btncol}>{copybtn}</td>
                    <td style={btncol}>{deletebtn}</td>
                    <td style={btncol}>{lastverbtn}</td>
                </tr>
            );
        });
        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Created</th>
                        <th>By</th>
                        <th>Last Modified</th>
                        <th>By</th>
                        <th></th>
                        <th></th>
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {rows}
                </tbody>
            </table>
        );
    }
}
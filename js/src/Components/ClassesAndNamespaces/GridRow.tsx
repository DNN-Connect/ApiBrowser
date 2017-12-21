import * as React from 'react';
import * as Models from '../../Models/';

interface IGridRowProps {
    module: Models.IAppModule;
    element: Models.INamespacesAndClass;
    detailLink: string;
};

interface IGridRowState {
    editing: boolean;
    currentValue: string;
    oldValue: string;
};

export default class GridRow extends React.Component<IGridRowProps, IGridRowState> {

    constructor(props: IGridRowProps) {
        super(props);
        var description = this.props.element.PendingDescription != null && this.props.element.LastModifiedByUserID == this.props.module.security.UserId ? this.props.element.PendingDescription : this.props.element.Description;
        this.state = {
            editing: false,
            currentValue: description,
            oldValue: ""
        }
    }

    private beginEdit(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        this.setState({
            editing: true,
            oldValue: this.state.currentValue
        });
    }

    private save(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        this.setState({
            editing: false
        }, () => {
            this.props.module.service.saveClassDescription(this.props.element.ClassId, this.state.currentValue, (description: string) => {
                this.setState({
                    currentValue: description
                });
            });
        });
    }

    private cancel(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        this.setState({
            editing: false,
            currentValue: this.state.oldValue
        });
    }

    private changeText(e: React.ChangeEvent<HTMLTextAreaElement>): void {
        this.setState({
            currentValue: e.target.value
        });
    }

    public render(): JSX.Element {
        var label = this.props.element.IsClass ? "Class" : "Namespace";
        var warning = this.props.element.IsDeprecated ? <span className="redhighlight">{this.props.module.resources.Deprecated}</span> : null;
        warning = this.props.element.DisappearedInVersion ? <span className="redhighlight">{this.props.module.resources.Removed}</span> : warning;
        var url = this.props.detailLink + "?view=" + this.props.element.Name;
        var editBtn = this.props.element.ClassId != -1 && this.props.module.security.CanComment && (this.props.element.PendingDescription == null || this.props.element.LastModifiedByUserID == this.props.module.security.UserId || this.props.module.security.CanModerate) ? (
            <span style={{ float: "right" }}>
                <a href="#" onClick={e => this.beginEdit(e)}><i className="glyphicon glyphicon-pencil"></i></a>
            </span>
        ) : null;
        var pendingEdit = (this.props.element.ClassId == -1 || this.props.element.PendingDescription == null) ? null : (
            <span className="redhighlight">Pending Edit</span>
        );
        var output = this.state.editing ? (
            <tr>
                <td colSpan={2}>
                    <a href={url}>{this.props.element.Name}</a>
                    <span className="greylabel">{label}</span>
                    {warning}
                    <br />
                    <textarea value={this.state.currentValue} className="form-control"
                        rows={3} onChange={e => this.changeText(e)}>
                    </textarea>
                    <br />
                    <div className="text-right">
                        <a href="#" className="btn btn-default" onClick={e => this.cancel(e)}>Cancel</a>
                        <a href="#" className="btn btn-primary" onClick={e => this.save(e)}>Save</a>
                    </div>
                </td>
            </tr>
        ) : (
                <tr>
                    <td>
                        <a href={url}>{this.props.element.Name}</a>
                        <span className="greylabel">{label}</span>
                        {warning}
                    </td>
                    <td>
                        {this.state.currentValue}
                        {pendingEdit}
                        {editBtn}
                    </td>
                </tr>
            );
        return output;
    }
}
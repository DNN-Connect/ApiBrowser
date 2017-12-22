import * as React from 'react';
import * as Models from '../../Models/';

interface IEditableTextProps {
    module: Models.IAppModule;
    element: Models.IClassOrMember;
    update: (description: string) => void;
};

interface IEditableTextState {
    editing: boolean;
    editValue: string;
};

export default class EditableText extends React.Component<IEditableTextProps, IEditableTextState> {

    refs: {
    }

    constructor(props: IEditableTextProps) {
        super(props);
        this.state = {
            editing: false,
            editValue: ""
        }
    }

    private beginEdit(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        var description = this.props.element.PendingDescription != null && this.props.element.LastModifiedByUserID == this.props.module.security.UserId ? this.props.element.PendingDescription : this.props.element.Description;
        this.setState({
            editing: true,
            editValue: description
        });
    }

    private save(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        this.setState({
            editing: false
        }, () => {
            this.props.update(this.state.editValue);
        });
    }

    private cancel(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        this.setState({
            editing: false,
            editValue: ""
        });
    }

    private changeText(e: React.ChangeEvent<HTMLTextAreaElement>): void {
        this.setState({
            editValue: e.target.value
        });
    }

    public render(): JSX.Element {
        var description = this.props.element.PendingDescription != null && this.props.element.LastModifiedByUserID == this.props.module.security.UserId ? this.props.element.PendingDescription : this.props.element.Description;
        var editBtn = this.props.element.ClassId != -1 && this.props.module.security.CanComment && (this.props.element.PendingDescription == null || this.props.element.LastModifiedByUserID == this.props.module.security.UserId || this.props.module.security.CanModerate) ? (
            <span style={{ float: "right" }}>
                <a href="#" onClick={e => this.beginEdit(e)}><i className="glyphicon glyphicon-pencil"></i></a>
            </span>
        ) : null;
        var pendingEdit = (this.props.element.ClassId == -1 || this.props.element.PendingDescription == null) ? null : (
            <span className="redhighlight">Pending Edit</span>
        );
        var output = this.state.editing ? (
            <div>
                <textarea value={this.state.editValue} className="form-control"
                    rows={3} onChange={e => this.changeText(e)}>
                </textarea>
                <br />
                <div className="text-right">
                    <a href="#" className="btn btn-default" onClick={e => this.cancel(e)}>{this.props.module.resources.Cancel}</a>
                    <a href="#" className="btn btn-primary" onClick={e => this.save(e)}>{this.props.module.resources.Save}</a>
                </div>
            </div>
        ) : (
                <p>
                    {description}
                    {pendingEdit}
                    {editBtn}
                </p>
            );
        return output;
    }
}
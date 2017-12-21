import * as React from 'react';
import * as Models from '../../Models/';

interface IEditableTextProps {
    module: Models.IAppModule;
    value: string;
    proposedValue: string;
};

interface IEditableTextState {
    editing: boolean
};

export default class EditableText extends React.Component<IEditableTextProps, IEditableTextState> {

    refs: {
    }

    constructor(props: IEditableTextProps) {
        super(props);
        this.state = {
            editing: false
        }
    }

    private beginEdit(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        this.setState({
            editing: true
        });
    }

    private save(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        this.setState({
            editing: false
        });
    }

    private cancel(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        this.setState({
            editing: false
        });
    }

    public render(): JSX.Element {
        var output = this.state.editing ? (
            <div className="input-group input-group-sm">
                <input type="text" value={this.props.value} className="form-control" />
                <span className="input-group-addon">
                    <a href="#" onClick={e => this.save(e)}>
                        <i className="glyphicon glyphicon-floppy-disk"></i>
                    </a>
                </span>
                <span className="input-group-addon">
                    <a href="#" onClick={e => this.cancel(e)}>
                        <i className="glyphicon glyphicon-remove"></i>
                    </a>
                </span>
            </div>
        ) : (
                <div>
                    <span>{this.props.value}</span>
                    <span style={{ float: "right" }}>
                        <a href="#" onClick={e => this.beginEdit(e)}><i className="glyphicon glyphicon-pencil"></i></a>
                    </span>
                </div>
            );
        return output;
    }
}
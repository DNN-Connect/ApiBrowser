import * as React from 'react';
import * as Models from '../../Models/';
import * as ReactMarkdown from 'react-markdown';

interface ICompareProps {
    module: Models.IAppModule;
    acceptChange: (item: Models.IModerationItem) => void;
    rejectChange: (item: Models.IModerationItem) => void;
};

interface ICompareState {
    item: Models.IModerationItem;
};

export default class Compare extends React.Component<ICompareProps, ICompareState> {

    refs: {
        dialog: any
    }

    constructor(props: ICompareProps) {
        super(props);
        this.state = {
            item: new Models.ModerationItem()
        }
    }

    public show(item: Models.IModerationItem): void {
        this.setState({
            item: item
        }, () => {
            ($(this.refs.dialog) as any).modal('show');
        });
    }

    private acceptChange(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        ($(this.refs.dialog) as any).modal('hide');
        this.props.acceptChange(this.state.item);
    }

    private rejectChange(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        ($(this.refs.dialog) as any).modal('hide');
        this.props.rejectChange(this.state.item);
    }

    public render(): JSX.Element {
        if (this.state.item.DocType == undefined) {
            return <span />;
        }
        var oldText = this.state.item.OldText ? this.state.item.DocType == 2 ? (
            <ReactMarkdown source={this.state.item.OldText} />
        ) : (
                <p>{this.state.item.OldText}</p>
            ) : null;
        var newText = this.state.item.DocType == 2 ? (
            <ReactMarkdown source={this.state.item.NewText} />
        ) : (
                <p>{this.state.item.NewText}</p>
            );
        return (
            <div className="modal fade" ref="dialog" role="dialog" aria-labelledby="cmModalLabel" aria-hidden="true">
                <div className="modal-dialog modal-lg">
                    <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 className="modal-title">{this.props.module.resources.Compare} {this.state.item.DocType == 2 ? this.props.module.resources.Documentation : this.props.module.resources.Description}</h4>
                        </div>
                        <div className="modal-body">
                            <div className="row">
                                <div className="col-sm-6"><strong>{this.props.module.resources.Current}</strong></div>
                                <div className="col-sm-6"><strong>{this.props.module.resources.Proposed}</strong></div>
                            </div>
                            <div className="row">
                                <div className="col-sm-6 bg-info">{oldText}</div>
                                <div className="col-sm-6 bg-warning">{newText}</div>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <a href="#" className="btn btn-danger"
                               onClick={e => this.rejectChange(e)}>{this.props.module.resources.Reject}</a>
                            <a href="#" className="btn btn-success"
                               onClick={e => this.acceptChange(e)}>{this.props.module.resources.Accept}</a>
                            <a href="#" className="btn btn-default" data-dismiss="modal">{this.props.module.resources.Close}</a>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
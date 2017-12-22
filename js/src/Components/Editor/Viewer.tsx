import * as React from 'react';
import * as Models from '../../Models/';
const ReactMarkdown = require('react-markdown');

interface IViewerProps {
    module: Models.IAppModule;
};

interface IViewerState {
    item: Models.IDocumentation;
};

export default class Viewer extends React.Component<IViewerProps, IViewerState> {

    refs: {
        dialog: any
    }

    constructor(props: IViewerProps) {
        super(props);
        this.state = {
            item: new Models.Documentation()
        }
    }

    public show(item: Models.IDocumentation): void {
        this.setState({
            item: item
        }, () => {
            ($(this.refs.dialog) as any).modal('show');
        });
    }

    public render(): JSX.Element {
        return (
            <div className="modal fade" ref="dialog" role="dialog" aria-labelledby="cmModalLabel" aria-hidden="true">
                <div className="modal-dialog modal-lg">
                    <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 className="modal-title">{this.props.module.resources.Documentation}</h4>
                        </div>
                        <div className="modal-body">
                            <ReactMarkdown source={this.state.item.Contents} />
                        </div>
                        <div className="modal-footer">
                            <a href="#" className="btn btn-default" data-dismiss="modal">{this.props.module.resources.Close}</a>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}
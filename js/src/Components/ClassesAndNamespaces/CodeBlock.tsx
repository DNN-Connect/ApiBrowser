import * as React from 'react';
import * as Models from '../../Models/';

interface ICodeBlockProps {
    module: Models.IAppModule;
};

interface ICodeBlockState {
    contents: Models.ICodeBlock | null;
};

declare var hljs: any;

export default class CodeBlock extends React.Component<ICodeBlockProps, ICodeBlockState> {
    refs: {
        dialog: any
        codeblock: HTMLElement;
    }

    constructor(props: ICodeBlockProps) {
        super(props);
        this.state = {
            contents: null
        }
    }

    public show(codeblockId: number): void {
        this.props.module.service.getCodeblock(codeblockId, (data: Models.ICodeBlock) => {
            this.setState({
                contents: data
            }, () => {
                ($(this.refs.dialog) as any).modal('show');
                hljs.highlightBlock(this.refs.codeblock);
            });
        });
    }

    public render(): JSX.Element {
        return (
            <div className="modal fade" ref="dialog" role="dialog" aria-labelledby="cmModalLabel" aria-hidden="true">
                <div className="modal-dialog modal-lg">
                    <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 className="modal-title">{this.props.module.resources.Code}</h4>
                        </div>
                        <div className="modal-body">
                            <pre>
                                <code className="cs" ref="codeblock">
                                    {this.state.contents ? this.state.contents.Body : ""}
                                </code>
                            </pre>
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
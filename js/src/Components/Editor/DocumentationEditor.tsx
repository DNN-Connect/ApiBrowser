import * as React from 'react';
import * as Models from '../../Models/';
const ReactMarkdown = require('react-markdown');

interface IDocumentationEditorProps {
    module: Models.IAppModule;
    history: Models.IDocumentation[];
    edit: Models.IDocumentation;
};

interface IDocumentationEditorState {
    currentContents: string;
};

export default class DocumentationEditor extends React.Component<IDocumentationEditorProps, IDocumentationEditorState> {

    refs: {
    }

    constructor(props: IDocumentationEditorProps) {
        super(props);
        this.state = {
            currentContents: "Type documentation here"
        }
    }

    public render(): JSX.Element {
        return (
            <div className="row">
                <div className="col-sm-6">
                    <textarea className="form-control" value={this.state.currentContents}
                        onChange={e => this.setState({ currentContents: e.target.value })} />
                </div>
                <div className="col-sm-6">
                    <ReactMarkdown source={this.state.currentContents} />
                </div>
            </div>
        );
    }
}
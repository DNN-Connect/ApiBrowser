import * as React from 'react';
import * as Models from '../../Models/';
import DocumentationList from './DocumentationList';
const ReactMarkdown = require('react-markdown');

interface IDocumentationEditorProps {
    module: Models.IAppModule;
    history: Models.IDocumentation[];
    edit: Models.IDocumentation;
    currentVersion: number | null;
};

interface IDocumentationEditorState {
    currentList: Models.IDocumentation[];
    currentEdit: Models.IDocumentation;
    changed: boolean;
};

export default class DocumentationEditor extends React.Component<IDocumentationEditorProps, IDocumentationEditorState> {

    refs: {
    }

    constructor(props: IDocumentationEditorProps) {
        super(props);
        var ce = new Models.Documentation();
        ce.FullName = props.edit.FullName;
        this.state = {
            currentList: props.history,
            currentEdit: ce,
            changed: false
        }
    }

    private save(e: React.MouseEvent<HTMLAnchorElement>): void {
        e.preventDefault();
        this.props.module.service.saveDocumentation(this.state.currentEdit, (doc: Models.IDocumentation) => {
            var added = false;
            var newList = this.state.currentList.map(d => {
                if (d.DocumentationId == doc.DocumentationId) added = true;
                return d.DocumentationId == doc.DocumentationId ? doc : d;
            });
            if (!added) newList.push(doc);
            var dcopy = Object.assign({}, doc);;
            this.setState({
                currentEdit: dcopy,
                currentList: newList,
                changed: false
            });
        });
    }
    private edit(d: Models.IDocumentation): void {
        if (this.state.changed) {
            if (!confirm("Do you wish to abandon current changes?")) {
                return;
            }
        }
        var dcopy = Object.assign({}, d);;
        this.setState({
            currentEdit: dcopy,
            changed: false
        });
    }
    private copy(d: Models.IDocumentation): void {
        if (this.state.changed) {
            if (!confirm("Do you wish to abandon current changes?")) {
                return;
            }
        }
        var dcopy = Object.assign({}, d);;
        dcopy.DocumentationId = -1;
        this.setState({
            currentEdit: dcopy,
            changed: false
        });
    }
    private delete(doc: Models.IDocumentation): void {
        this.props.module.service.deleteDocumentation(doc.DocumentationId, () => {
            var newList = this.state.currentList;
            var index = newList.indexOf(doc);
            if (index > -1) {
                newList.splice(index, 1);
            }
            this.setState({
                currentList: newList
            });
            if (doc.DocumentationId == this.state.currentEdit.DocumentationId) {
                var ce = new Models.Documentation();
                ce.FullName = this.props.edit.FullName;
                this.setState({
                    currentEdit: ce,
                    changed: false
                });
            }
        });
    }
    private setCrtVersion(doc: Models.IDocumentation): void {
        this.props.module.service.setCurrentVersion(doc.DocumentationId, () => {
            var newList = this.state.currentList.map(d => {
                d.IsCurrentVersion = false;
                if (d.DocumentationId == doc.DocumentationId) d.IsCurrentVersion = true;
                return d;
            });
            this.setState({
                currentList: newList
            });
        });
    }

    public render(): JSX.Element {
        return (
            <div>
                <div className="row">
                    <div className="col-sm-12">
                        <DocumentationList module={this.props.module}
                            list={this.state.currentList}
                            edit={d => this.edit(d)}
                            copy={d => this.copy(d)}
                            delete={d => this.delete(d)}
                            setLastVersion={d => this.setCrtVersion(d)}
                        />
                    </div>
                </div>
                <div className="row">
                    <div className="col-sm-6">
                        <textarea className="form-control" value={this.state.currentEdit.Contents}
                            rows={this.state.currentEdit.Contents.split(/\r\n|\r|\n/).length + 5}
                            wrap="off"
                            placeholder="Type documentation in Markdown here"
                            onChange={e => { var d = this.state.currentEdit; d.Contents = e.target.value; this.setState({ currentEdit: d, changed: true }) }} />
                    </div>
                    <div className="col-sm-6">
                        <ReactMarkdown source={this.state.currentEdit.Contents} />
                    </div>
                </div>
                <div className="text-right">
                    <a href="#" className="btn btn-primary"
                        onClick={e => this.save(e)}>Save</a>
                </div>
            </div>
        );
    }
}
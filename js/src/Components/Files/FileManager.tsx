import * as React from 'react';
import * as Models from '../../Models/';

interface IFileManagerProps {
    module: Models.IAppModule;
};

interface IFileManagerState {
    files: Models.IScheduledFile[];
    uploading: boolean;
};

export default class FileManager extends React.Component<IFileManagerProps, IFileManagerState> {

    constructor(props: IFileManagerProps) {
        super(props);
        this.state = {
            files: [],
            uploading: false
        }
    }

    componentDidMount() {
        this.updateFiles();
        $('input[data-action="upload"]').on('change', (e: any) => {
            if (!this.state.uploading) {
                this.setState({
                    uploading: true
                }, () => {
                    var files = e.target.files;
                    var that = this;
                    this.props.module.service.postFiles(files, (data: Models.IScheduledFile[]) => {
                        that.setState({
                            files: data,
                            uploading: false
                        });
                        e.target.value = "";
                    }, (err: any) => {
                        that.setState({
                            uploading: false
                        });
                        e.target.value = "";
                    });
                });
            }
        });
    }

    private updateFiles(): void {
        this.props.module.service.getScheduledFiles((data: Models.IScheduledFile[]) => {
            this.setState({
                files: data
            }, () => {
                var that = this;
                setTimeout(function () { that.updateFiles(); }, 10000);
            });
        });
    }

    private processFiles(): void {
        this.props.module.service.processFiles((data: Models.IScheduledFile[]) => {
            this.setState({
                files: data
            });
        });
    }

    public render(): JSX.Element {
        var rows = this.state.files.map(f => {
            var processing = f.Processing ? (
                <span className="redhighlight">{this.props.module.resources.Processing}</span>
            ) : null;
            return (
                <tr key={f.Name}>
                    <td>{f.Name} {processing}</td>
                    <td>{f.Size}</td>
                </tr>
            );
        });
        var uploading = this.state.uploading ? (
            <div className="row">
                <div className="col-sm-12">
                    <div className="alert alert-info">
                        <span className="glyphicon glyphicon-refresh spinning"></span>
                        {this.props.module.resources.Uploading}
                    </div>
                </div>
            </div>
        ) : null;
        return (
            <div>
                <div className="row">
                    <div className="form-group">
                        <label htmlFor="Documents" className="col-sm-2 control-label">{this.props.module.resources.Files}</label>
                        <div className="col-sm-9">
                            <input type="file" className="form-control" data-action="upload" multiple />
                        </div>
                        <div className="col-sm-1">
                            <a href="#" className="btn btn-default" onClick={e => { e.preventDefault(); this.processFiles() }}>{this.props.module.resources.Process}</a>
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                {uploading}
                <table className="table">
                    <tbody>
                        {rows}
                    </tbody>
                </table>
            </div>
        );
    }
}
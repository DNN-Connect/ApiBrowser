import * as React from 'react';
import * as Models from '../../Models/';

interface IGridProps {
    module: Models.IAppModule;
    detailLink: string;
};

interface IGridState {
    searchText: string;
    list: Models.INamespacesAndClass[];
    classes: boolean;
    namespaces: boolean;
    pageIndex: number;
    pageSize: number;
    total: number;
    loading: boolean;
    lastPage: boolean;
};

export default class Grid extends React.Component<IGridProps, IGridState> {

    refs: {
        test: HTMLDivElement
    }

    constructor(props: IGridProps) {
        super(props);
        this.state = {
            searchText: "",
            list: [],
            classes: true,
            namespaces: true,
            pageIndex: 0,
            pageSize: 25,
            total: 0,
            loading: false,
            lastPage: true
        }
    }

    componentDidMount() {
        this.getData(true);
        window.addEventListener('scroll', this.handleScroll.bind(this));
    }

    componentWillUnmount() {
        window.removeEventListener('scroll', this.handleScroll.bind(this));
    }

    private handleScroll(event: any) {
        if (this.isScrolledIntoView(this.refs.test)) {
            this.loadMore();
        }
    }

    private loadMore(): void {
        if (this.state.lastPage) return;
        this.setState({
            pageIndex: this.state.pageIndex + 1
        }, () => {
            this.getData(false);
        })
    }

    private isScrolledIntoView(elem: HTMLElement) {
        if ($(elem).offset() == undefined) return false;
        var docViewTop = $(window).scrollTop() as number;
        var docViewBottom = docViewTop + ($(window).height() as number);
        var elemTop = ($(elem).offset() as JQuery.Coordinates).top;
        var elemBottom = elemTop + ($(elem).height() as number);
        return ((elemBottom <= docViewBottom) && (elemTop >= docViewTop));
    }

    private getData(clear: boolean): void {
        this.setState({ loading: true }, () => {
            this.props.module.service.getAll(this.state.classes, this.state.namespaces, this.state.searchText, this.state.pageIndex, this.state.pageSize, (data: any) => {
                var newList = this.state.list;
                newList = clear ? data.data : newList.concat(data.data);
                this.setState({
                    list: newList,
                    total: data.TotalCount,
                    loading: false,
                    lastPage: data.IsLastPage
                });
            })
        });
    }

    private search(e: React.ChangeEvent<HTMLInputElement>): void {
        this.setState({
            searchText: e.target.value
        }, () => {
            if (!this.state.loading) {
                this.getData(true);
            }
        })
    }

    private changeType(newValue: string): void {
        switch (newValue) {
            case 'all':
                this.setState({
                    classes: true,
                    namespaces: true
                });
                break;
            case 'class':
                this.setState({
                    classes: true,
                    namespaces: false
                });
                break;
            case 'namespace':
                this.setState({
                    classes: false,
                    namespaces: true
                });
                break;
        }
        this.getData(true);
    }

    public render(): JSX.Element {
        var rows = this.state.list.map(e => {
            var label = e.IsClass ? "Class" : "Namespace";
            var warning = e.IsDeprecated ? <span className="redhighlight">{this.props.module.resources.Deprecated}</span> : null;
            warning = e.DisappearedInVersion ? <span className="redhighlight">{this.props.module.resources.Removed}</span> : warning;
            var url = this.props.detailLink + "?view=" + e.Name;
            return (
                <tr key={e.Name}>
                    <td>
                        <a href={url}>{e.Name}</a>
                        <span className="greylabel">{label}</span>
                        {warning}
                    </td>
                    <td>{e.Description}</td>
                </tr>
            );
        });
        var loadMore = this.state.loading || this.state.lastPage ? null : (
            <div ref="test" className="btn btn-default btn-block" onClick={e => this.loadMore()}>Load More</div>
        );
        return (
            <div>
                <div className="row">
                    <div className="col-sm-4 listoptions">
                        <input type="radio" name="cl" value="all" checked={this.state.classes && this.state.namespaces} onChange={e => this.changeType('all')} />
                        <span>All</span>
                        <input type="radio" name="cl" value="class" checked={this.state.classes && !this.state.namespaces} onChange={e => this.changeType('class')} />
                        <span>Classes</span>
                        <input type="radio" name="cl" value="namespace" checked={!this.state.classes && this.state.namespaces} onChange={e => this.changeType('namespace')} />
                        <span>Namespaces</span>
                    </div>
                    <div className="col-sm-8">
                        <div className="input-group">
                            <span className="input-group-addon"><i className="glyphicon glyphicon-search"></i></span>
                            <input type="text" className="form-control" value={this.state.searchText} onChange={e => this.search(e)} />
                        </div>
                    </div>
                </div>
                <table className="table">
                    <tbody>
                        {rows}
                    </tbody>
                </table>
                {loadMore}
            </div>
        );
    }
}
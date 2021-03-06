import * as React from "react";
import * as Models from "../../Models/";
import GridRow from "./GridRow";

interface IGridProps {
  module: Models.IAppModule;
  detailLink: string;
}

interface IGridState {
  searchText: string;
  list: Models.INamespacesClassesAndMember[];
  mainType: number;
  subType: number;
  status: number;
  pageIndex: number;
  pageSize: number;
  total: number;
  loading: boolean;
  lastPage: boolean;
}

export default class Grid extends React.Component<IGridProps, IGridState> {
  refs: {
    test: HTMLDivElement;
  };

  constructor(props: IGridProps) {
    super(props);
    this.state = {
      searchText: "",
      list: [],
      mainType: -1,
      subType: -1,
      status: -1,
      pageIndex: 0,
      pageSize: 25,
      total: 0,
      loading: false,
      lastPage: true
    };
  }

  componentDidMount() {
    this.getData(true);
    window.addEventListener("scroll", this.handleScroll.bind(this));
  }

  componentWillUnmount() {
    window.removeEventListener("scroll", this.handleScroll.bind(this));
  }

  private handleScroll(event: any) {
    if (this.isScrolledIntoView(this.refs.test)) {
      this.loadMore();
    }
  }

  private loadMore(): void {
    if (this.state.lastPage) return;
    this.setState(
      {
        pageIndex: this.state.pageIndex + 1
      },
      () => {
        this.getData(false);
      }
    );
  }

  private isScrolledIntoView(elem: HTMLElement) {
    if ($(elem).offset() == undefined) return false;
    var docViewTop = $(window).scrollTop() as number;
    var docViewBottom = docViewTop + ($(window).height() as number);
    var elemTop = ($(elem).offset() as JQuery.Coordinates).top;
    var elemBottom = elemTop + ($(elem).height() as number);
    return elemBottom <= docViewBottom && elemTop >= docViewTop;
  }

  private getData(clear: boolean): void {
    this.setState({ loading: true }, () => {
      this.props.module.service.getAll(
        this.state.mainType,
        this.state.subType,
        this.state.status,
        this.state.searchText,
        this.state.pageIndex,
        this.state.pageSize,
        (data: any) => {
          var newList = this.state.list;
          newList = clear ? data.data : newList.concat(data.data);
          this.setState({
            list: newList,
            total: data.TotalCount,
            loading: false,
            lastPage: data.IsLastPage
          });
        }
      );
    });
  }

  private search(e: React.ChangeEvent<HTMLInputElement>): void {
    this.setState(
      {
        searchText: e.target.value
      },
      () => {
        if (!this.state.loading) {
          this.getData(true);
        }
      }
    );
  }

  private changeType(newValue: string): void {
    switch (newValue) {
      case "all":
        this.setState({
          mainType: -1
        });
        break;
      case "class":
        this.setState({
          mainType: 1
        });
        break;
      case "namespace":
        this.setState({
          mainType: 0
        });
        break;
      case "member":
        this.setState({
          mainType: 2
        });
        break;
    }
    this.getData(true);
  }

  public render(): JSX.Element {
    var rows = this.state.list.map(e => {
      return (
        <GridRow
          module={this.props.module}
          key={e.Name}
          element={e}
          detailLink={this.props.detailLink}
        />
      );
    });
    var loadMore =
      this.state.loading || this.state.lastPage ? null : (
        <div
          ref="test"
          className="btn btn-default btn-block"
          onClick={e => this.loadMore()}
        >
          {this.props.module.resources.LoadMore}
        </div>
      );
    return (
      <div>
        <div className="row">
          <div className="col-sm-4 listoptions">
            <input
              type="radio"
              name="cl"
              value="all"
              checked={this.state.mainType == -1}
              onChange={e => this.changeType("all")}
            />
            <span>{this.props.module.resources.All}</span>
            <input
              type="radio"
              name="cl"
              value="namespace"
              checked={this.state.mainType == 0}
              onChange={e => this.changeType("namespace")}
            />
            <span>{this.props.module.resources.Namespaces}</span>
            <input
              type="radio"
              name="cl"
              value="class"
              checked={this.state.mainType == 1}
              onChange={e => this.changeType("class")}
            />
            <span>{this.props.module.resources.Classes}</span>
            <input
              type="radio"
              name="cl"
              value="member"
              checked={this.state.mainType == 2}
              onChange={e => this.changeType("member")}
            />
            <span>{this.props.module.resources.Members}</span>
          </div>
          <div className="col-sm-8">
            <div className="input-group">
              <span className="input-group-addon">
                <i className="glyphicon glyphicon-search" />
              </span>
              <input
                type="text"
                className="form-control"
                value={this.state.searchText}
                onChange={e => this.search(e)}
              />
            </div>
          </div>
        </div>
        <table className="table">
          <tbody>{rows}</tbody>
        </table>
        {loadMore}
      </div>
    );
  }
}

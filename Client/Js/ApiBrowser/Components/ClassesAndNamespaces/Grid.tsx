import {
  createSignal,
  Component,
  createEffect,
  For,
  onCleanup,
} from "solid-js";
import { IAppModule } from "../../Models/IAppModule";
import { INamespacesClassesAndMember } from "../../Models/INamespacesClassesAndMember";
import GridRow from "./GridRow";

interface IGridProps {
  module: IAppModule;
  detailLink: string;
}

const Grid: Component<IGridProps> = (props) => {
  const [searchText, setSearchText] = createSignal("");
  const [mainType, setMainType] = createSignal(0);
  const [subType, setSubType] = createSignal(-1);
  const [status, setStatus] = createSignal(-1);
  const [pageIndex, setPageIndex] = createSignal(0);
  const [pageSize, setPageSize] = createSignal(25);
  const [total, setTotal] = createSignal(0);
  const [loading, setLoading] = createSignal(false);
  const [lastPage, setLastPage] = createSignal(false);
  const [list, setList] = createSignal<INamespacesClassesAndMember[]>([]);
  let loadMoreDiv;

  createEffect(() => {
    setLoading(true);
    props.module.service.getAll(
      mainType(),
      subType(),
      status(),
      searchText(),
      pageIndex(),
      pageSize(),
      (data: any) => {
        var newList = list();
        newList = newList.concat(data.data);
        setList(newList);
        setTotal(data.TotalCount);
        setLastPage(data.IsLastPage);
        setLoading(false);
      }
    );
  });

  createEffect(() => {
    window.addEventListener("scroll", handleScroll.bind(this));
  });

  onCleanup(() => {
    window.removeEventListener("scroll", handleScroll.bind(this));
  });

  const handleScroll = (event: any) => {
    if (isScrolledIntoView(loadMoreDiv) && !loading()) {
      setPageIndex(pageIndex() + 1);
    }
  };

  const reset = (fn: () => void) => {
    setList([]);
    setPageIndex(0);
    fn();
  };

  const isScrolledIntoView = (elem: HTMLElement) => {
    if ($(elem).offset() == undefined) return false;
    var docViewTop = $(window).scrollTop() as number;
    var docViewBottom = docViewTop + ($(window).height() as number);
    var elemTop = ($(elem).offset() as JQuery.Coordinates).top;
    var elemBottom = elemTop + ($(elem).height() as number);
    return elemBottom <= docViewBottom && elemTop >= docViewTop;
  };

  const loadMoreButton =
    loading() || lastPage() ? null : (
      <div
        class="btn btn-outline-secondary btn-block"
        onClick={(e) => setPageIndex(pageIndex() + 1)}
        ref={loadMoreDiv}
      >
        {props.module.resources.LoadMore}
      </div>
    );

  return (
    <div>
      <div class="row">
        <div class="col-sm-4 listoptions">
          <input
            type="radio"
            name="cl"
            value="all"
            checked={mainType() === -1}
            onChange={(e) => reset(() => setMainType(-1))}
          />
          <span>{props.module.resources.All}</span>
          <input
            type="radio"
            name="cl"
            value="namespace"
            checked={mainType() === 0}
            onChange={(e) => reset(() => setMainType(0))}
          />
          <span>{props.module.resources.Namespaces}</span>
          <input
            type="radio"
            name="cl"
            value="class"
            checked={mainType() === 1}
            onChange={(e) => reset(() => setMainType(1))}
          />
          <span>{props.module.resources.Classes}</span>
          <input
            type="radio"
            name="cl"
            value="member"
            checked={mainType() === 2}
            onChange={(e) => reset(() => setMainType(2))}
          />
          <span>{props.module.resources.Members}</span>
        </div>
        <div class="col-sm-8">
          <div class="input-group ml-2">
            <span class="input-group-text">
              <i class="fas fa-search" />
            </span>
            <input
              type="text"
              class="form-control"
              value={searchText()}
              onChange={(e) =>
                reset(() => setSearchText(e.currentTarget.value))
              }
            />
          </div>
        </div>
      </div>
      <table class="table">
        <tbody>
          <For each={list()}>
            {(e) => (
              <GridRow
                module={props.module}
                element={e}
                detailLink={props.detailLink}
              />
            )}
          </For>
        </tbody>
      </table>
      {loadMoreButton}
    </div>
  );
};

export default Grid;

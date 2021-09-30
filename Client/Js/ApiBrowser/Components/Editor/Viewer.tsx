import {
  createSignal,
  Component,
  createEffect,
  For,
  onCleanup,
} from "solid-js";
import { IAppModule } from "../../Models/IAppModule";
import { Documentation, IDocumentation } from "../../Models/IDocumentation";
import MarkdownBlock from "../Generic/MarkdownBlock";

interface IViewerProps {
  module: IAppModule;
  docToView: IDocumentation | null;
}

const Viewer: Component<IViewerProps> = (props) => {
  const [item, setItem] = createSignal<IDocumentation>(new Documentation());
  let dialog;

  createEffect(() => {
    if (props.docToView == null) return;
    setItem(props.docToView);
    ($(dialog) as any).modal("show");
  });

  return (
    <div
      class="modal fade"
      ref={dialog}
      role="dialog"
      aria-labelledby="cmModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
          <h5 class="modal-title">{props.module.resources.Documentation}</h5>
            <button
              type="button"
              class="btn-close"
              data-bs-dismiss="modal"
              aria-label="Close"
            >
            </button>
          </div>
          <div class="modal-body">
            <MarkdownBlock source={item().Contents} />
          </div>
          <div class="modal-footer">
            <a href="#" class="btn btn-outline-secondary" data-dismiss="modal">
              {props.module.resources.Close}
            </a>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Viewer;

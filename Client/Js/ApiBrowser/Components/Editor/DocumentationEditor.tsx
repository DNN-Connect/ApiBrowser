import {
  createSignal,
  Component,
  createEffect,
  For,
  onCleanup,
  onMount,
} from "solid-js";
import DocumentationList from "./DocumentationList";
import Viewer from "./Viewer";
import { IAppModule } from "../../Models/IAppModule";
import { Documentation, IDocumentation } from "../../Models/IDocumentation";
import MarkdownBlock from "../Generic/MarkdownBlock";

interface IDocumentationEditorProps {
  module: IAppModule;
  history: IDocumentation[];
  edit: IDocumentation;
  currentVersion: number | null;
}

const DocumentationEditor: Component<IDocumentationEditorProps> = (props) => {
  var ce = new Documentation();
  ce.FullName = props.edit.FullName;
  const [currentList, setCurrentList] = createSignal<IDocumentation[]>(
    props.history
  );
  const [currentEdit, setCurrentEdit] = createSignal<IDocumentation>(ce);
  const [changed, setChanged] = createSignal(false);
  const [docToView, setDocToView] = createSignal<IDocumentation | null>(null);

  onMount(() => {
    console.log("onMount");
  });

  const save = (
    e: MouseEvent & {
      currentTarget: HTMLAnchorElement;
      target: Element;
    }
  ) => {
    e.preventDefault();
    props.module.service.saveDocumentation(
      currentEdit(),
      (doc: IDocumentation) => {
        var added = false;
        var newList = currentList().map((d) => {
          if (d.DocumentationId == doc.DocumentationId) added = true;
          return d.DocumentationId == doc.DocumentationId ? doc : d;
        });
        if (!added) newList.push(doc);
        var dcopy = Object.assign({}, doc);
        setCurrentEdit(dcopy);
        setCurrentList(newList);
        setChanged(false);
      }
    );
  };

  const edit = (d: IDocumentation) => {
    if (changed()) {
      if (!confirm("Do you wish to abandon current changes?")) {
        return;
      }
    }
    var dcopy = Object.assign({}, d);
    setCurrentEdit(dcopy);
    setChanged(false);
  };

  const copy = (d: IDocumentation) => {
    if (changed()) {
      if (!confirm("Do you wish to abandon current changes?")) {
        return;
      }
    }
    var dcopy = Object.assign({}, d);
    dcopy.DocumentationId = -1;
    setCurrentEdit(dcopy);
    setChanged(false);
  };

  const onDelete = (doc: IDocumentation) => {
    props.module.service.deleteDocumentation(doc.DocumentationId, () => {
      var newList = currentList();
      var index = newList.indexOf(doc);
      if (index > -1) {
        newList.splice(index, 1);
      }
      setCurrentList(newList);
      if (doc.DocumentationId == currentEdit().DocumentationId) {
        var ce = new Documentation();
        ce.FullName = props.edit.FullName;
        setCurrentEdit(ce);
        setChanged(false);
      }
    });
  };

  const setCrtVersion = (doc: IDocumentation) => {
    props.module.service.setCurrentVersion(doc.DocumentationId, () => {
      var newList = currentList().map((d) => {
        d.IsCurrentVersion = false;
        if (d.DocumentationId == doc.DocumentationId) d.IsCurrentVersion = true;
        return d;
      });
      setCurrentList(newList);
    });
  };

  return (
    <div>
      <div class="row">
        <div class="col-sm-12">
          <DocumentationList
            module={props.module}
            list={currentList()}
            edit={(d) => edit(d)}
            copy={(d) => copy(d)}
            delete={(d) => onDelete(d)}
            setLastVersion={(d) => setCrtVersion(d)}
            show={(d) => setDocToView(d)}
          />
        </div>
      </div>
      <div class="row">
        <div class="col-sm-6">
          <textarea
            class="form-control"
            value={currentEdit().Contents}
            rows={currentEdit().Contents.split(/\r\n|\r|\n/).length + 5}
            wrap="off"
            placeholder="Type documentation in Markdown here"
            onChange={(e) => {
              var d = currentEdit();
              d.Contents = e.currentTarget.value;
              setCurrentEdit(d);
              setChanged(true);
            }}
          />
        </div>
        <div class="col-sm-6">
          <MarkdownBlock source={currentEdit().Contents} />
        </div>
      </div>
      <div class="text-right">
        <a href="#" class="btn btn-primary mb-4" onClick={(e) => save(e)}>
          Save
        </a>
      </div>
      <Viewer module={props.module} docToView={docToView()} />
    </div>
  );
};

export default DocumentationEditor;

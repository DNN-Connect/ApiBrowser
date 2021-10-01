import { createSignal, Component, For, Show, onMount } from "solid-js";
import { IAppModule } from "../../Models/IAppModule";
import { IScheduledFile } from "../../Models/IScheduledFile";

interface IFileManagerProps {
  module: IAppModule;
}

const FileManager: Component<IFileManagerProps> = (props) => {
  const [files, setFiles] = createSignal<IScheduledFile[]>([]);
  const [uploading, setUploading] = createSignal(false);

  onMount(() => {
    $('input[data-action="upload"]').on("change", (e: any) => {
      if (!uploading()) {
        setUploading(true);
        var files = e.target.files;
        var that = this;
        props.module.service.postFiles(
          files,
          (data: IScheduledFile[]) => {
            setFiles(data);
            setUploading(false);
            e.target.value = "";
          },
          (err: any) => {
            setUploading(false);
            e.target.value = "";
          }
        );
      }
    });
    updateFiles();
  });

  const updateFiles = () => {
    props.module.service.getScheduledFiles((data: IScheduledFile[]) => {
      setFiles(data);
      setTimeout(() => {
        updateFiles();
      }, 10000);
    });
  };

  const processFiles = () => {
    props.module.service.processFiles((data: IScheduledFile[]) => {
      setFiles(data);
    });
  };

  return (
    <div>
      <div class="d-flex my-3 align-items-center ms-2">
        <label htmlFor="Documents">{props.module.resources.Files}</label>
        <div class="ms-3">
          <input
            type="file"
            class="form-control"
            data-action="upload"
            multiple
          />
        </div>
        <div class="ms-3">
          <a
            href="#"
            class="btn btn-secondary"
            onClick={(e) => {
              e.preventDefault();
              processFiles();
            }}
          >
            {props.module.resources.Process}
          </a>
        </div>
      </div>
      <div>&nbsp;</div>
      <Show when={uploading()}>
        <div class="row">
          <div class="col-sm-12">
            <div class="alert alert-info">
              <span class="fas fa-sync spinning"></span>
              {props.module.resources.Uploading}
            </div>
          </div>
        </div>
      </Show>
      <table class="table">
        <tbody>
          <For each={files()}>
            {(f) => {
              const processing = f.Processing ? (
                <span class="redhighlight">
                  {props.module.resources.Processing}
                </span>
              ) : null;
              return (
                <tr>
                  <td>
                    {f.Name} {processing}
                  </td>
                  <td>{f.Size}</td>
                </tr>
              );
            }}
          </For>
        </tbody>
      </table>
    </div>
  );
};

export default FileManager;

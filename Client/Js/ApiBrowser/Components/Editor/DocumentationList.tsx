import {
  createSignal,
  Component,
  createEffect,
  For,
  onCleanup,
} from "solid-js";
import { IAppModule } from "../../Models/IAppModule";
import { IDocumentation } from "../../Models/IDocumentation";

interface IDocumentationListProps {
  module: IAppModule;
  list: IDocumentation[];
  edit: (d: IDocumentation) => void;
  copy: (d: IDocumentation) => void;
  delete: (d: IDocumentation) => void;
  setLastVersion: (d: IDocumentation) => void;
  show: (d: IDocumentation) => void;
}

const DocumentationList: Component<IDocumentationListProps> = (props) => {
  const btncol = {
    width: "30px",
  };
  const dateFormatter = new Intl.DateTimeFormat(props.module.locale, {
    year: "numeric",
    month: "numeric",
    day: "numeric",
  });
  return (
    <table class="table">
      <thead>
        <tr>
          <th>ID</th>
          <th>{props.module.resources.Created}</th>
          <th>{props.module.resources.By}</th>
          <th>{props.module.resources.LastModified}</th>
          <th>{props.module.resources.By}</th>
          <th></th>
          <th></th>
          <th></th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <For each={props.list}>
          {(d) => {
            var lastverbtn = props.module.security.CanModerate ? (
              d.IsCurrentVersion ? null : (
                <a
                  href="#"
                  class="btn btn-default"
                  onClick={(e) => {
                    e.preventDefault();
                    props.setLastVersion(d);
                  }}
                >
                  <i class="glyphicon glyphicon-asterisk"></i>
                </a>
              )
            ) : null;
            var editbtn =
              props.module.security.CanModerate ||
              d.CreatedByUserID == props.module.security.UserId ? (
                <a
                  href="#"
                  class="btn btn-default"
                  onClick={(e) => {
                    e.preventDefault();
                    props.edit(d);
                  }}
                >
                  <i class="glyphicon glyphicon-pencil"></i>
                </a>
              ) : null;
            var copybtn = props.module.security.CanComment ? (
              <a
                href="#"
                class="btn btn-default"
                onClick={(e) => {
                  e.preventDefault();
                  props.copy(d);
                }}
              >
                <i class="glyphicon glyphicon-repeat"></i>
              </a>
            ) : null;
            var deletebtn =
              props.module.security.CanModerate ||
              d.CreatedByUserID == props.module.security.UserId ? (
                <a
                  href="#"
                  class="btn btn-default"
                  onClick={(e) => {
                    e.preventDefault();
                    props.delete(d);
                  }}
                >
                  <i class="glyphicon glyphicon-remove"></i>
                </a>
              ) : null;
            return (
              <tr>
                <td>{d.DocumentationId}</td>
                <td>{dateFormatter.format(new Date(d.CreatedOnDate))}</td>
                <td>{d.CreatedByUserDisplayName}</td>
                <td>{dateFormatter.format(new Date(d.LastModifiedOnDate))}</td>
                <td>{d.LastModifiedByUserDisplayName}</td>
                <td style={btncol}>
                  <a
                    href="#"
                    class="btn btn-info"
                    onClick={(e) => {
                      e.preventDefault();
                      props.show(d);
                    }}
                  >
                    <i class="glyphicon glyphicon-eye-open"></i>
                  </a>
                </td>
                <td style={btncol}>{editbtn}</td>
                <td style={btncol}>{copybtn}</td>
                <td style={btncol}>{deletebtn}</td>
                <td style={btncol}>{lastverbtn}</td>
              </tr>
            );
          }}
        </For>
      </tbody>
    </table>
  );
};

export default DocumentationList;

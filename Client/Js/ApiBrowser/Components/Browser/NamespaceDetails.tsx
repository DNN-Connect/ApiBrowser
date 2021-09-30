import {
  Component,
  For,
  JSX,
} from "solid-js";
import { IApiClass } from "../../Models/IApiClass";
import { IApiNamespace } from "../../Models/IApiNamespace";
import { IAppModule } from "../../Models/IAppModule";
import { IMember } from "../../Models/IMember";

interface INamespaceDetailsProps {
  module: IAppModule;
  namespace: IApiNamespace;
  classes: IApiClass[];
  changeSelection: (
    newClass: IApiClass | null,
    newMember: IMember | null
  ) => void;
}

const NamespaceDetails: Component<INamespaceDetailsProps> = (props) => {
  return (
    <div class="content">
      <h2>{props.namespace.NamespaceName} Namespace</h2>
      <p>{props.namespace.Description}</p>
      <h3>{props.module.resources.Classes}</h3>
      <table>
        <tbody>
          <For each={props.classes}>
            {(c) => {
              let warning: JSX.Element | null = null;
              if (c.IsDeprecated) {
                warning = <span class="redhighlight">Deprecated</span>;
              }
              if (c.DisappearedInVersion) {
                warning = <span class="redhighlight">Removed</span>;
              }
              return (
                <tr>
                  <td>
                    <a
                      href="#"
                      onClick={(e) => {
                        e.preventDefault();
                        props.changeSelection(c, null);
                      }}
                    >
                      {c.ClassName}
                    </a>
                    {warning}
                  </td>
                  <td>{c.Description}</td>
                </tr>
              );
            }}
          </For>
        </tbody>
      </table>
    </div>
  );
};

export default NamespaceDetails;

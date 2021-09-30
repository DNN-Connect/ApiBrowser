import {
  createSignal,
  Component,
  createEffect,
  For,
  onCleanup,
  Show,
} from "solid-js";
import MemberList from "./MemberList";
import EditableText from "../Generic/EditableText";
import MarkdownBlock from "../Generic/MarkdownBlock";
import { IAppModule } from "../../Models/IAppModule";
import { IApiClass } from "../../Models/IApiClass";
import { IMember } from "../../Models/IMember";
import { IClassOrMember } from "../../Models/IClassOrMember";
declare var Prism: any;

interface IClassDetailsProps {
  module: IAppModule;
  apiclass: IApiClass;
  changeSelection: (
    newClass: IApiClass | null,
    newMember: IMember | null
  ) => void;
  documentationLink: string;
  updateDescription: (id: number, description: string) => void;
}

const ClassDetails: Component<IClassDetailsProps> = (props) => {
  let declaration;
  createEffect(() => {
    Prism.highlightAll();
  });
  return (
    <div class="content">
      <h2>{props.apiclass.ClassName} Class</h2>
      <Show when={props.apiclass.DeprecationMessage !== undefined}>
        <div class="alert alert-danger">
          {props.apiclass.DeprecationMessage}
        </div>
      </Show>
      <dl class="dl-horizontal">
        <dt>Namespace:</dt>
        <dd>
          <a
            href="#"
            onClick={(e) => {
              e.preventDefault();
              props.changeSelection(null, null);
            }}
          >
            {props.apiclass.NamespaceName}
          </a>
        </dd>
        <dt>Assembly:</dt>
        <dd>{props.apiclass.ComponentName}</dd>
        <dt>{props.module.resources.FirstDetected}:</dt>
        <dd>{props.apiclass.AppearedInVersion}</dd>
        <Show when={props.apiclass.DeprecatedInVersion}>
          <dt class="red">Deprecated in:</dt>
          <dd class="red">{props.apiclass.DeprecatedInVersion}</dd>
        </Show>
        <Show when={props.apiclass.DisappearedInVersion}>
          <dt class="red">Disappeared in:</dt>
          <dd class="red">{props.apiclass.DisappearedInVersion}</dd>
        </Show>
      </dl>
      <h4>{props.module.resources.Description}</h4>
      <EditableText
        module={props.module}
        element={props.apiclass as IClassOrMember}
        update={(description) =>
          props.updateDescription(props.apiclass.ClassId, description)
        }
      />
      <h4>{props.module.resources.Declaration}</h4>
      <pre>
        <code class="language-csharp" ref={declaration}>
          {props.apiclass.Declaration}
        </code>
      </pre>
      <Show when={props.apiclass.Members}>
        <MemberList
          module={props.module}
          members={props.apiclass.Members as IMember[]}
          changeSelection={(a, b) => props.changeSelection(props.apiclass, b)}
        />
      </Show>
      <h4>
        {props.module.resources.Documentation}
        <Show when={props.module.security.CanComment}>
          <span style={{ float: "right" }}>
            <a
              href={
                props.documentationLink +
                "?name=" +
                props.apiclass.FullQualifier
              }
            >
              <i class="fas fa-edit"></i>
            </a>
          </span>
        </Show>
      </h4>
      <Show when={props.apiclass.DocumentationContents}>
        <MarkdownBlock source={props.apiclass.DocumentationContents} />
      </Show>
    </div>
  );
};

export default ClassDetails;

import {
  createSignal,
  Component,
  createEffect,
  For,
  Show,
  onCleanup,
  Switch,
  Match,
} from "solid-js";
import EditableText from "../Generic/EditableText";
import MarkdownBlock from "../Generic/MarkdownBlock";
import { IAppModule } from "../../Models/IAppModule";
import { IMember } from "../../Models/IMember";
import { IApiClass } from "../../Models/IApiClass";
import { IMemberCodeBlock } from "../../Models/IMemberCodeBlock";
import { IReference } from "../../Models/IReference";
import { ICodeBlock } from "../../Models/ICodeBlock";
import { IClassOrMember } from "../../Models/IClassOrMember";
declare var Prism: any;

interface IMemberDetailsProps {
  module: IAppModule;
  member: IMember;
  classes: IApiClass[];
  changeSelection: (
    newClass: IApiClass | null,
    newMember: IMember | null
  ) => void;
  apiclass: IApiClass;
  codeblocks: IMemberCodeBlock[];
  documentationLink: string;
  updateDescription: (id: number, description: string) => void;
}

const MemberDetails: Component<IMemberDetailsProps> = (props) => {
  const [incomingReferences, setIncomingReferences] = createSignal<
    IReference[]
  >([]);
  const [outgoingReferences, setOutgoingReferences] = createSignal<
    IReference[]
  >([]);
  const [currentCodeblock, setCurrentCodeblock] =
    createSignal<ICodeBlock | null>(null);
  let codeblock, declaration;
  createEffect(() => {
    props.module.service.getReferencesToMember(
      props.member.MemberId,
      (data: IReference[]) => {
        setIncomingReferences(data);
      }
    );
    Prism.manual = true;
    Prism.highlightAll();
  });

  const getUrl = (memberFullname: string) => {
    for (var i = 0; i < props.classes.length; i++) {
      var c = props.classes[i];
      if (c.Members) {
        for (var j = 0; j < c.Members.length; j++) {
          var m = c.Members[j];
          if (
            m.NamespaceName + "." + m.ClassName + "." + m.MemberName ==
            memberFullname
          ) {
            return {
              class: c,
              member: m,
            };
          }
        }
      }
    }
    return window.location.pathname + "?view=" + memberFullname;
  };

  const showCodeBlock = (codeblockId: number) => {
    props.module.service.getCodeblock(codeblockId, (data: ICodeBlock) => {
      setCurrentCodeblock(null);
      setCurrentCodeblock(data);
      Prism.highlightAll();
    });
  };

  var memType = "";
  switch (props.member.MemberType) {
    case 0:
      memType = "Constructor";
      break;
    case 1:
      memType = "Method";
      break;
    case 2:
      memType = "Field";
      break;
    case 3:
      memType = "Property";
      break;
    case 4:
      memType = "Event";
      break;
  }

  return (
    <div class="content">
      <h2>
        {props.member.ClassName}.{props.member.MemberName} {memType}
      </h2>
      <Switch>
        <Match when={props.member.DeprecationMessage !== undefined}>
          <div class="alert alert-danger">
            {props.member.DeprecationMessage}
          </div>
        </Match>
        <Match when={props.apiclass.DeprecationMessage !== undefined}>
          <div class="alert alert-danger">
            {props.apiclass.DeprecationMessage}
          </div>
        </Match>
      </Switch>
      <dl class="dl-horizontal">
        <dt>Class:</dt>
        <dd>
          <a
            href="#"
            onClick={(e) => {
              e.preventDefault();
              props.changeSelection(props.apiclass, null);
            }}
          >
            {props.member.ClassName}
          </a>
        </dd>
        <dt>Namespace:</dt>
        <dd>
          <a
            href="#"
            onClick={(e) => {
              e.preventDefault();
              props.changeSelection(null, null);
            }}
          >
            {props.member.NamespaceName}
          </a>
        </dd>
        <dt>Assembly:</dt>
        <dd>{props.member.ComponentName}</dd>
        <dt>{props.module.resources.FirstDetected}:</dt>
        <dd>{props.member.AppearedInVersion}</dd>
        <Show when={props.member.DeprecatedInVersion}>
          <dt class="red">Deprecated in:</dt>
          <dd class="red">{props.member.DeprecatedInVersion}</dd>
        </Show>
        <Show when={props.member.DisappearedInVersion}>
          <dt class="red">Disappeared in:</dt>
          <dd class="red">{props.member.DisappearedInVersion}</dd>
        </Show>
        <dt>{props.module.resources.Codeblocks}:</dt>
        <dd>{props.member.CodeBlockCount}</dd>
      </dl>
      <h4>{props.module.resources.Description}</h4>
      <EditableText
        module={props.module}
        element={props.member as IClassOrMember}
        update={(description) =>
          props.updateDescription(props.member.MemberId, description)
        }
      />
      <h4>{props.module.resources.Declaration}</h4>
      <pre ref={declaration}>
        <code class="language-csharp">{props.member.Declaration}</code>
      </pre>
      <h4>{props.module.resources.Codeblocks}</h4>
      <Show when={currentCodeblock()}>
        <pre ref={codeblock}>
          <code class="language-csharp">
            {(currentCodeblock() as ICodeBlock).Body}
          </code>
        </pre>
      </Show>
      <table>
        <thead>
          <tr>
            <th>{props.module.resources.Version}</th>
            <th>{props.module.resources.File}</th>
            <th>{props.module.resources.Lines}</th>
            <th />
          </tr>
        </thead>
        <tbody>
          <For each={props.codeblocks}>
            {(cb) => (
              <tr>
                <td>{cb.Version}</td>
                <td>{cb.FileName}</td>
                <td>
                  {cb.StartLine} - {cb.EndLine}
                </td>
                <td style={{ width: "32px" }}>
                  <a
                    href="#"
                    class="btn btn-sm btn-outline-secondary"
                    onClick={(e) => {
                      e.preventDefault();
                      showCodeBlock(cb.CodeBlockId);
                    }}
                  >
                    <i class="fas fa-eye" /> &gt;
                  </a>
                </td>
              </tr>
            )}
          </For>
        </tbody>
      </table>
      <Show when={incomingReferences.length > 0}>
        <div>
          <h4>References</h4>
          <table>
            <tbody>
              <For each={incomingReferences()}>
                {(r) => {
                  const url = getUrl(r.FromRefFullQualifier);
                  if (typeof url === "string") {
                    return (
                      <tr>
                        <td>
                          <a href={url}>
                            {r.FromRefClassName}::{r.FromRefMemberName}
                          </a>
                        </td>
                      </tr>
                    );
                  } else {
                    return (
                      <tr>
                        <td>
                          <a
                            href="#"
                            onClick={(e) => {
                              e.preventDefault();
                              props.changeSelection(
                                (url as any).class as IApiClass,
                                (url as any).member as IMember
                              );
                            }}
                          >
                            {r.FromRefClassName}::{r.FromRefMemberName}
                          </a>
                        </td>
                      </tr>
                    );
                  }
                }}
              </For>
            </tbody>
          </table>
        </div>
      </Show>
      <h4>
        {props.module.resources.Documentation}
        <Show when={props.module.security.CanComment}>
          <span style={{ float: "right" }}>
            <a
              href={
                props.documentationLink + "?name=" + props.member.FullQualifier
              }
            >
              <i class="fas fa-edit"></i>
            </a>
          </span>
        </Show>
      </h4>
      <Show when={props.member.DocumentationContents}>
        <MarkdownBlock source={props.member.DocumentationContents} />
      </Show>
    </div>
  );
};

export default MemberDetails;

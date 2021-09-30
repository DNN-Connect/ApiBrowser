import { Component, For } from "solid-js";
import { IApiClass } from "../../Models/IApiClass";
import { IAppModule } from "../../Models/IAppModule";
import { IMember } from "../../Models/IMember";

interface IBrowserNavBarClassProps {
  module: IAppModule;
  classes: IApiClass[];
  selectedClassId: number;
  selectedMemberId: number;
  class: IApiClass;
  level: number;
  changeSelection: (
    newClass: IApiClass | null,
    newMember: IMember | null
  ) => void;
}

const BrowserNavBarClass: Component<IBrowserNavBarClassProps> = (props) => {
  return (
    <li>
      <a
        href="#"
        class={
          "toc-h toc-h" +
          props.level.toString() +
          " toc-link" +
          (props.selectedMemberId == -1 &&
          props.selectedClassId == props.class.ClassId
            ? " active"
            : "")
        }
        onClick={(e) => {
          e.preventDefault();
          props.changeSelection(props.class, null);
        }}
      >
        {props.class.ClassName}
      </a>
      <ul class={"toc-list-h" + (props.level + 1).toString()}>
        <For each={props.class.Members}>
          {(m) => (
            <li>
              <a
                class={
                  "toc-item toc-h" +
                  (props.level + 1).toString() +
                  " toc-link" +
                  (props.selectedMemberId == m.MemberId ? " active" : "")
                }
                href="#"
                onClick={(e) => {
                  e.preventDefault();
                  props.changeSelection(props.class, m);
                }}
              >
                {m.MemberName}
              </a>
            </li>
          )}
        </For>
        <For each={props.classes}>
          {(c) =>
            c.ParentClassId == props.class.ClassId ? (
              <BrowserNavBarClass
                module={props.module}
                classes={props.classes}
                selectedClassId={props.selectedClassId}
                selectedMemberId={props.selectedMemberId}
                class={c}
                level={props.level + 1}
                changeSelection={(c, m) => props.changeSelection(c, m)}
              />
            ) : null
          }
        </For>
      </ul>
    </li>
  );
};

export default BrowserNavBarClass;

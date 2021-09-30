import { Component, For } from "solid-js";
import { IApiClass } from "../../Models/IApiClass";
import { IApiNamespace } from "../../Models/IApiNamespace";
import { IAppModule } from "../../Models/IAppModule";
import { IMember } from "../../Models/IMember";
import BrowserNavBarClass from "./BrowserNavBarClass";

interface IBrowserNavBarProps {
  module: IAppModule;
  namespace: IApiNamespace;
  classes: IApiClass[];
  selectedClassId: number;
  selectedMemberId: number;
  changeSelection: (
    newClass: IApiClass | null,
    newMember: IMember | null
  ) => void;
}

const BrowserNavBar: Component<IBrowserNavBarProps> = (props) => {
  return (
    <div id="toc" class="toc-list-h1">
      <For each={props.classes}>
        {(c) =>
          c.ParentClassId === -1 ? (
            <BrowserNavBarClass
              module={props.module}
              classes={props.classes}
              selectedClassId={props.selectedClassId}
              selectedMemberId={props.selectedMemberId}
              class={c}
              level={1}
              changeSelection={(c, m) => props.changeSelection(c, m)}
            />
          ) : null
        }
      </For>
    </div>
  );
};

export default BrowserNavBar;

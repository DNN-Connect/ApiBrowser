import {
  createSignal,
  Component,
  createEffect,
  For,
  Switch,
  Match,
} from "solid-js";
import { IApiClass } from "../../Models/IApiClass";
import { IAppModule } from "../../Models/IAppModule";
import { IMember } from "../../Models/IMember";

interface IMemberSublistProps {
  module: IAppModule;
  title: string;
  members: IMember[];
  memberType: number;
  changeSelection: (
    newClass: IApiClass | null,
    newMember: IMember | null
  ) => void;
}

const MemberSublist: Component<IMemberSublistProps> = (props) => {
  const [members, setMembers] = createSignal<IMember[]>([]);

  createEffect(() => {
    const newMembers: IMember[] = [];
    for (var i = 0; i < props.members.length; i++) {
      var m = props.members[i];
      if (m.MemberType == props.memberType) {
        newMembers.push(m);
      }
    }
    setMembers(newMembers);
  });

  console.log(members());

  return (
    <Switch>
      <Match when={members().length === 0}>
        <span></span>
      </Match>
      <Match when={members().length !== 0}>
        <div>
          <h6>{props.title}</h6>
          <table class="table">
            <tbody>
              <For each={members()}>
                {(m) => (
                  <tr>
                    <td>
                      <a
                        href="#"
                        onClick={(e) => {
                          e.preventDefault();
                          props.changeSelection(null, m);
                        }}
                      >
                        {m.MemberName}
                      </a>
                    </td>
                    <td>{m.Description}</td>
                  </tr>
                )}
              </For>
            </tbody>
          </table>
        </div>
      </Match>
    </Switch>
  );
};

export default MemberSublist;

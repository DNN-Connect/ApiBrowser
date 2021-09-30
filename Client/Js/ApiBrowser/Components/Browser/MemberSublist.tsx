import {
  createSignal,
  Component,
  createEffect,
  For,
  onCleanup,
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
  let members: IMember[] = [];
  for (var i = 0; i < props.members.length; i++) {
    var m = props.members[i];
    if (m.MemberType == props.memberType) {
      members.push(m);
    }
  }
  if (members.length == 0) {
    return <span></span>;
  }

  return (
    <div>
      <h6>{props.title}</h6>
      <table>
        <tbody>
          <For each={props.members}>
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
  );
};

export default MemberSublist;

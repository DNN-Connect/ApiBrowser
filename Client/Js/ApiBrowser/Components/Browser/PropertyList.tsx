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

interface IPropertyListProps {
  module: IAppModule;
  title: string;
  members: IMember[];
  changeSelection: (
    newClass: IApiClass | null,
    newMember: IMember | null
  ) => void;
}

interface IProperties {
  [name: string]: {
    getter: IMember | null;
    setter: IMember | null;
  }
}

const PropertyList: Component<IPropertyListProps> = (props) => {
  const [properties, setProperties] = createSignal<IProperties>({});

  createEffect(() => {
    const newProps = {};
    for (var i = 0; i < props.members.length; i++) {
      var m = props.members[i];
      if (m.MemberType == 3) {
        if (!newProps[m.MemberName]) {
          newProps[m.MemberName] = { getter: null, setter: null };
        }
        if (m.IsGetter) {
          newProps[m.MemberName].getter = m;
        }
        if (m.IsSetter) {
          newProps[m.MemberName].setter = m;
        }
      }
    }
    setProperties(newProps);
  });

  return (
    <Switch>
      <Match when={Object.keys(properties()).length === 0}>
        <span></span>
      </Match>
      <Match when={Object.keys(properties()).length !== 0}>
        <div>
          <h6>{props.title}</h6>
          <table class="table">
            <tbody>
              <For each={Object.keys(properties())}>
                {(m) => (
                  <tr>
                    <td>
                      {m}
                    </td>
                    <td className="propgetset">
                      {properties()[m].getter && <a
                        href="#"
                        onClick={(e) => {
                          e.preventDefault();
                          props.changeSelection(null, properties()[m].getter);
                        }}
                      >
                        Get
                      </a>}
                      {properties()[m].setter && <a
                        href="#"
                        onClick={(e) => {
                          e.preventDefault();
                          props.changeSelection(null, properties()[m].setter);
                        }}
                      >
                        Set
                      </a>}
                    </td>
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

export default PropertyList;

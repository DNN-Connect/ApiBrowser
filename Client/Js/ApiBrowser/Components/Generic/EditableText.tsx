import { createSignal, Component, Show, Switch, Match } from "solid-js";
import { IAppModule } from "../../Models/IAppModule";
import { IClassOrMember } from "../../Models/IClassOrMember";

interface IEditableTextProps {
  module: IAppModule;
  element: IClassOrMember;
  update: (description: string) => void;
}

const EditableText: Component<IEditableTextProps> = (props) => {
  const [editing, setEditing] = createSignal(false);
  const [editValue, setEditValue] = createSignal("");

  const beginEdit = (
    e: MouseEvent & {
      currentTarget: HTMLAnchorElement;
      target: Element;
    }
  ) => {
    e.preventDefault();
    var description =
      props.element.PendingDescription != null &&
      props.element.LastModifiedByUserID == props.module.security.UserId
        ? props.element.PendingDescription
        : props.element.Description;
    setEditing(true);
    setEditValue(description);
  };
  const save = (
    e: MouseEvent & {
      currentTarget: HTMLAnchorElement;
      target: Element;
    }
  ) => {
    e.preventDefault();
    props.update(editValue());
    setEditing(false);
  };
  const cancel = (
    e: MouseEvent & {
      currentTarget: HTMLAnchorElement;
      target: Element;
    }
  ) => {
    e.preventDefault();
    setEditing(false);
    setEditValue("");
  };

  const description =
    props.element.PendingDescription != null &&
    props.element.LastModifiedByUserID == props.module.security.UserId
      ? props.element.PendingDescription
      : props.element.Description;
  const editBtn =
    props.element.ClassId != -1 &&
    props.module.security.CanComment &&
    (props.element.PendingDescription == null ||
      props.element.LastModifiedByUserID == props.module.security.UserId ||
      props.module.security.CanModerate) ? (
      <span style={{ float: "right" }}>
        <a href="#" onClick={(e) => beginEdit(e)}>
          <i class="fas fa-edit"></i>
        </a>
      </span>
    ) : null;

  return (
    <Switch>
      <Match when={editing()}>
        <div>
          <textarea
            value={editValue()}
            class="form-control"
            rows={3}
            onChange={(e) => setEditValue(e.currentTarget.value)}
          ></textarea>
          <br />
          <div class="text-right">
            <a href="#" class="btn btn-outline-secondary" onClick={(e) => cancel(e)}>
              {props.module.resources.Cancel}
            </a>
            <a href="#" class="btn btn-primary" onClick={(e) => save(e)}>
              {props.module.resources.Save}
            </a>
          </div>
        </div>
      </Match>
      <Match when={!editing()}>
        <p>
          {description}
          <Show
            when={
              props.element.ClassId !== -1 &&
              props.element.PendingDescription !== null
            }
          >
            <span class="redhighlight">Pending Edit</span>
          </Show>
          {editBtn}
        </p>
      </Match>
    </Switch>
  );
};

export default EditableText;

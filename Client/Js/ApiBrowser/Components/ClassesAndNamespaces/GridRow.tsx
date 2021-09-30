import { createSignal, Component, createEffect } from "solid-js";
import { IApiClass } from "../../Models/IApiClass";
import { IAppModule } from "../../Models/IAppModule";
import { INamespacesClassesAndMember } from "../../Models/INamespacesClassesAndMember";

interface IGridRowProps {
  module: IAppModule;
  element: INamespacesClassesAndMember;
  detailLink: string;
}

interface IGridRowState {
  editing: boolean;
  currentValue: string;
  oldValue: string;
}

const GridRow: Component<IGridRowProps> = (props) => {
  const description =
    props.element.PendingDescription != null &&
    props.element.LastModifiedByUserID == props.module.security.UserId
      ? props.element.PendingDescription
      : props.element.Description;

  const [editing, setEditing] = createSignal(false);
  const [currentValue, setCurrentValue] = createSignal(description);
  const [oldValue, setOldValue] = createSignal("");

  const beginEdit = (
    e: MouseEvent & {
      currentTarget: HTMLAnchorElement;
      target: Element;
    }
  ) => {
    e.preventDefault();
    setEditing(true);
    setOldValue(currentValue());
  };

  const save = (
    e: MouseEvent & {
      currentTarget: HTMLAnchorElement;
      target: Element;
    }
  ) => {
    e.preventDefault();
    setEditing(false);
    props.module.service.saveClassDescription(
      props.element.ClassId,
      currentValue(),
      (c: IApiClass) => {
        const description =
          c.PendingDescription != null &&
          c.LastModifiedByUserID == props.module.security.UserId
            ? c.PendingDescription
            : c.Description;
        setCurrentValue(description);
      }
    );
  };

  const cancel = (
    e: MouseEvent & {
      currentTarget: HTMLAnchorElement;
      target: Element;
    }
  ) => {
    e.preventDefault();
    setEditing(false);
    setCurrentValue(oldValue());
  };

  const label =
    props.element.MainType === 0
      ? "Namespace"
      : props.element.MainType === 1
      ? "Class"
      : "Member";
  let warning = props.element.IsDeprecated ? (
    <span class="redhighlight">{props.module.resources.Deprecated}</span>
  ) : null;
  warning = props.element.DisappearedInVersion ? (
    <span class="redhighlight">{props.module.resources.Removed}</span>
  ) : (
    warning
  );
  const url = props.detailLink + "?view=" + props.element.Name;
  const editBtn =
    props.element.ClassId != -1 &&
    props.module.security.CanComment &&
    (props.element.PendingDescription === null ||
      props.element.LastModifiedByUserID === props.module.security.UserId ||
      props.module.security.CanModerate) ? (
      <span style={{ float: "right" }}>
        <a href="#" onClick={(e) => beginEdit(e)}>
          <i class="glyphicon glyphicon-pencil"></i>
        </a>
      </span>
    ) : null;
  const pendingEdit =
    props.element.ClassId == -1 ||
    props.element.PendingDescription == null ? null : (
      <span class="redhighlight">Pending Edit</span>
    );
  return editing() ? (
    <tr>
      <td colSpan={2}>
        <a href={url}>{props.element.Name}</a>
        <span class="greylabel">{label}</span>
        {warning}
        <br />
        <textarea
          value={currentValue()}
          class="form-control"
          rows={3}
          onChange={(e) => setCurrentValue(e.currentTarget.value)}
        ></textarea>
        <br />
        <div class="text-right">
          <a href="#" class="btn btn-default" onClick={(e) => cancel(e)}>
            {props.module.resources.Cancel}
          </a>
          <a href="#" class="btn btn-primary" onClick={(e) => save(e)}>
            {props.module.resources.Save}
          </a>
        </div>
      </td>
    </tr>
  ) : (
    <tr>
      <td>
        <a href={url}>{props.element.Name}</a>
        <span class="greylabel">{label}</span>
        {warning}
      </td>
      <td>
        {currentValue()}
        {pendingEdit}
        {editBtn}
      </td>
    </tr>
  );
};

export default GridRow;

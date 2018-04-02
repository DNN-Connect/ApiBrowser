import * as React from "react";
import * as Models from "../../Models/";

interface IBrowserNavBarClassProps {
  module: Models.IAppModule;
  classes: Models.IApiClass[];
  class: Models.IApiClass;
  level: number;
  changeSelection: (
    newClass: Models.IApiClass | null,
    newMember: Models.IMember | null
  ) => void;
}

export default class BrowserNavBarClass extends React.Component<
  IBrowserNavBarClassProps
> {
  public render(): JSX.Element {
    var members = this.props.class.Members
      ? this.props.class.Members.map(m => {
          return (
            <li key={m.MemberId}>
              <a
                className="sidebar-nav-item"
                href="#"
                onClick={e => {
                  e.preventDefault();
                  this.props.changeSelection(this.props.class, m);
                }}
              >
                {m.MemberName}
              </a>
            </li>
          );
        })
      : null;
    var subClasses: JSX.Element[] = [];
    this.props.classes.forEach(c => {
      if (c.ParentClassId == this.props.class.ClassId) {
        subClasses.push(
          <BrowserNavBarClass
            key={c.ClassId}
            module={this.props.module}
            classes={this.props.classes}
            class={c}
            level={this.props.level + 1}
            changeSelection={(c, m) => this.props.changeSelection(c, m)}
          />
        );
      }
    });
    return (
      <div className={"sidebar-level-" + this.props.level.toString()}>
        <h5 className="sidebar-nav-heading">
          <a
            href="#"
            onClick={e => {
              e.preventDefault();
              this.props.changeSelection(this.props.class, null);
            }}
          >
            {this.props.class.ClassName}
          </a>
        </h5>
        <ul className="sidebar-nav-items">{members}</ul>
        {subClasses}
      </div>
    );
  }
}

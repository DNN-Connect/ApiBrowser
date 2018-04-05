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
                className={
                  "toc-h" + (this.props.level + 1).toString() + " toc-link"
                }
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
      <li>
        <a
          href="#"
          className={"toc-h" + this.props.level.toString() + " toc-link"}
          onClick={e => {
            e.preventDefault();
            this.props.changeSelection(this.props.class, null);
          }}
        >
          {this.props.class.ClassName}
        </a>
        <ul
          className={"toc-list-h" + (this.props.level + 1).toString()}
          style={{ display: "inherit" }}
        >
          {members}
          {subClasses}
        </ul>
      </li>
    );
  }
}

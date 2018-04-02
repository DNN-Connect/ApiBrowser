import * as React from "react";
import * as Models from "../../Models/";
import BrowserNavBarClass from "./BrowserNavBarClass";

interface IBrowserNavBarProps {
  module: Models.IAppModule;
  namespace: Models.IApiNamespace;
  classes: Models.IApiClass[];
  changeSelection: (
    newClass: Models.IApiClass | null,
    newMember: Models.IMember | null
  ) => void;
}

export default class BrowserNavBar extends React.Component<
  IBrowserNavBarProps
> {
  public render(): JSX.Element {
    var mainClasses: JSX.Element[] = [];
    this.props.classes.forEach(c => {
      if (c.ParentClassId == -1) {
        mainClasses.push(
          <BrowserNavBarClass
            key={c.ClassId}
            module={this.props.module}
            classes={this.props.classes}
            class={c}
            level={0}
            changeSelection={(c, m) => this.props.changeSelection(c, m)}
          />
        );
      }
    });
    return (
      <nav role="navigation" className="sidebar-nav">
        {mainClasses}
      </nav>
    );
  }
}

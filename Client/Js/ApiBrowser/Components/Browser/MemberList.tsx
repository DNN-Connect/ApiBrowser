import { Component } from "solid-js";
import { IApiClass } from "../../Models/IApiClass";
import { IAppModule } from "../../Models/IAppModule";
import { IMember } from "../../Models/IMember";
import MemberSublist from "./MemberSublist";
import PropertyList from "./PropertyList";

interface IMemberListProps {
  module: IAppModule;
  members: IMember[];
  changeSelection: (
    newClass: IApiClass | null,
    newMember: IMember | null
  ) => void;
}

const MemberList: Component<IMemberListProps> = (props) => {
  return (
    <div>
      <h4>{props.module.resources.Members}</h4>
      <MemberSublist
        module={props.module}
        title="Constructors"
        members={props.members}
        memberType={0}
        changeSelection={(a, b) => props.changeSelection(a, b)}
      />
      <MemberSublist
        module={props.module}
        title="Fields"
        members={props.members}
        memberType={2}
        changeSelection={(a, b) => props.changeSelection(a, b)}
      />
      <PropertyList
        module={props.module}
        title="Properties"
        members={props.members}
        changeSelection={(a, b) => props.changeSelection(a, b)}
      />
      <MemberSublist
        module={props.module}
        title="Methods"
        members={props.members}
        memberType={1}
        changeSelection={(a, b) => props.changeSelection(a, b)}
      />
      <MemberSublist
        module={props.module}
        title="Events"
        members={props.members}
        memberType={4}
        changeSelection={(a, b) => props.changeSelection(a, b)}
      />
    </div>
  );
};

export default MemberList;

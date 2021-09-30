import { IAppModule } from "../../Models/IAppModule";
import {
  createSignal,
  Component,
  createEffect,
  Show,
  Switch,
  Match,
  onMount,
} from "solid-js";
import ClassDetails from "./ClassDetails";
import MemberDetails from "./MemberDetails";
import NamespaceDetails from "./NamespaceDetails";
import BrowserNavBar from "./BrowserNavBar";
import { IViewSelection } from "../../Models/IViewSelection";
import { IApiClass } from "../../Models/IApiClass";
import { IMember } from "../../Models/IMember";
import { IMemberCodeBlock } from "../../Models/IMemberCodeBlock";

interface IBrowserProps {
  module: IAppModule;
  selection: IViewSelection;
  classes: IApiClass[];
  documentationLink: string;
  returnLink: string;
}

const Browser: Component<IBrowserProps> = (props) => {
  const [selectedClass, setSelectedClass] = createSignal<IApiClass | null>(
    props.selection.SelectedClass
  );
  const [selectedMember, setSelectedMember] = createSignal<IMember | null>(
    props.selection.SelectedMember
  );
  const [selectedMemberCodeblocks, setSelectedMemberCodeblocks] = createSignal<
    IMemberCodeBlock[]
  >([]);
  const [classes, setClasses] = createSignal<IApiClass[]>(props.classes);

  onMount(() => {
    props.classes.forEach((c) => {
      checkClass(c);
    });
    var body = document.getElementsByTagName("body");
    if (body) body[0].style.paddingLeft = "230px";
    if (selectedMember() != null) {
      props.module.service.getMemberCodeBlocks(
        (selectedMember() as IMember).MemberId,
        (data: IMemberCodeBlock[]) => {
          setSelectedMemberCodeblocks(data);
        }
      );
    }
  });

  const checkClass = (classToCheck: IApiClass) => {
    if (classToCheck.Members == undefined) {
      props.module.service.getMembers(
        classToCheck.ClassId,
        (data: IMember[]) => {
          var c = classToCheck;
          c.Members = data;
          var classList = classes().map((cl) => {
            return cl.ClassId == c.ClassId ? c : cl;
          });
          setClasses(classList);
          const sc = selectedClass();
          if (sc && sc.ClassId == classToCheck.ClassId) {
            setSelectedClass(c);
          }
        }
      );
    }
  };

  const getUrl = () => {
    var url = [location.protocol, "//", location.host, location.pathname].join(
      ""
    );
    url += "?view=" + props.selection.SelectedNamespace.NamespaceName;
    const sc = selectedClass();
    url += sc == null ? "" : "." + sc.ClassName;
    const sm = selectedMember();
    url += sm == null ? "" : "." + sm.MemberName;
    return url;
  };

  const changeUrl = (newUrl: string) => {
    window.history.pushState(null, document.title, newUrl);
  };

  const changeSelection = (
    newClass: IApiClass | null,
    newMember: IMember | null
  ) => {
    var codeblocks = selectedMemberCodeblocks();
    if (newMember == null && selectedMember() != null) {
      codeblocks = [];
    } else if (newMember != null) {
      const sm = selectedMember();
      if (sm == null || sm.MemberId != newMember.MemberId) {
        codeblocks = [];
        props.module.service.getMemberCodeBlocks(
          newMember.MemberId,
          (data: IMemberCodeBlock[]) => {
            setSelectedMemberCodeblocks(data);
          }
        );
      }
    }
    setSelectedClass(newClass);
    setSelectedMember(newMember);
    setSelectedMemberCodeblocks(codeblocks);
    changeUrl(getUrl());
  };

  const editMemberDescription = (memberId: number, newDescription: string) => {
    props.module.service.saveMemberDescription(
      memberId,
      newDescription,
      (member: IMember) => {
        var apiClass = selectedClass();
        var newClassList = classes().map((c) => {
          if (c.ClassId == member.ClassId) {
            var newMembers = (c.Members as IMember[]).map((m) => {
              return m.MemberId == member.MemberId ? member : m;
            });
            c.Members = newMembers;
            apiClass = c;
          }
          return c;
        });
        setSelectedClass(apiClass);
        setClasses(newClassList);
      }
    );
  };

  const editClassDescription = (classId: number, newDescription: string) => {
    props.module.service.saveClassDescription(
      classId,
      newDescription,
      (apiClass: IApiClass) => {
        var newClassList = classes().map((c) => {
          return c.ClassId == classId ? apiClass : c;
        });
        setSelectedClass(apiClass);
        setClasses(newClassList);
      }
    );
  };

  return (
    <div>
      <div className="toc-wrapper">
        <a href={props.returnLink} className="toc-h1 toc-link mb-1">
          {props.module.resources.Namespaces}
        </a>
        <hr class="mb-3" />
        <a
          href="#"
          className={
            "toc-ns toc-h1 toc-link" +
            (selectedClass() == null ? " active" : "")
          }
          onClick={(e) => {
            e.preventDefault();
            changeSelection(null, null);
          }}
        >
          {props.selection.SelectedNamespace.NamespaceName}
        </a>
        <BrowserNavBar
          module={props.module}
          namespace={props.selection.SelectedNamespace}
          classes={classes()}
          selectedClassId={
            selectedClass() == null
              ? -1
              : (selectedClass() as IApiClass).ClassId
          }
          selectedMemberId={
            selectedMember() == null
              ? -1
              : (selectedMember() as IMember).MemberId
          }
          changeSelection={(c, m) => changeSelection(c, m)}
        />
      </div>
      <div className="page-wrapper pb-4">
        <div className="dark-box" />
        <Switch>
          <Match when={selectedClass() === null}>
            <NamespaceDetails
              module={props.module}
              namespace={props.selection.SelectedNamespace}
              classes={classes()}
              changeSelection={(a, b) => changeSelection(a, b)}
            />
          </Match>
          <Match when={selectedClass() !== null}>
            <Switch>
              <Match when={selectedMember() === null}>
                <ClassDetails
                  module={props.module}
                  apiclass={selectedClass() as IApiClass}
                  changeSelection={(a, b) => changeSelection(a, b)}
                  documentationLink={props.documentationLink}
                  updateDescription={(a, b) => editClassDescription(a, b)}
                />
              </Match>
              <Match when={selectedMember() !== null}>
                <MemberDetails
                  module={props.module}
                  classes={classes()}
                  member={selectedMember() as IMember}
                  apiclass={selectedClass() as IApiClass}
                  changeSelection={(a, b) => changeSelection(a, b)}
                  codeblocks={selectedMemberCodeblocks() as IMemberCodeBlock[]}
                  documentationLink={props.documentationLink}
                  updateDescription={(a, b) => editMemberDescription(a, b)}
                />
              </Match>
            </Switch>
          </Match>
        </Switch>
      </div>
    </div>
  );
};

export default Browser;

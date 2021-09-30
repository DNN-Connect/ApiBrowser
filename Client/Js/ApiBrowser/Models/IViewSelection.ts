import { IApiNamespace } from "./IApiNamespace";
import { IApiClass } from "./IApiClass";
import { IMember } from "./IMember";
export interface IViewSelection {
    SelectedNamespace: IApiNamespace,
    SelectedClass: IApiClass | null,
    SelectedMember: IMember | null
}
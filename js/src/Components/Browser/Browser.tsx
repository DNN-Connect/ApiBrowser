import * as React from 'react';
import * as Models from '../../Models/';
import ClassTree from './ClassTree';
import ClassDetails from './ClassDetails';
import MemberDetails from './MemberDetails';
import NamespaceDetails from './NamespaceDetails';

interface IBrowserProps {
    module: Models.AppModule;
    selection: Models.IViewSelection;
    classes: Models.ApiClass[];
};

interface IBrowserState {
    selectedClass: Models.ApiClass | null;
    selectedMember: Models.Member | null;
};

export default class Browser extends React.Component<IBrowserProps, IBrowserState> {

    refs: {
    }

    constructor(props: IBrowserProps) {
        super(props);
        this.state = {
            selectedClass: props.selection.SelectedClass,
            selectedMember: props.selection.SelectedMember
        }
    }

    componentDidMount() {
        this.checkSelectedClass();
        window.onpopstate = function(e) {
            location.reload();
        }
    }

    private checkSelectedClass(): void {
        if (this.state.selectedClass && this.state.selectedClass.Members == undefined) {
            this.props.module.service.getMembers(this.state.selectedClass.ClassId, (data: Models.IMember[]) => {
                var c = (this.state.selectedClass as Models.IApiClass);
                c.Members = data;
                this.setState({
                    selectedClass: c
                });
            });
        }
    }

    private getUrl(): string {
        var url = [location.protocol, '//', location.host, location.pathname].join('');
        url += "?view=" + this.props.selection.SelectedNamespace.NamespaceName;
        url += this.state.selectedClass == null ? "" : "." + this.state.selectedClass.ClassName;
        url += this.state.selectedMember == null ? "" : "." + this.state.selectedMember.MemberName;
        return url;
    }

    private changeUrl(newUrl: string): void {
        window.history.pushState(null, document.title, newUrl);
    }

    private changeSelection(newClass: Models.IApiClass | null, newMember: Models.IMember | null): void {
        this.setState({
            selectedClass: newClass,
            selectedMember: newMember
        }, () => {
            this.changeUrl(this.getUrl());
            this.checkSelectedClass();
        });
    }

    public render(): JSX.Element {
        var mainScreen = this.state.selectedClass == null ? (
            <NamespaceDetails module={this.props.module}
                namespace={this.props.selection.SelectedNamespace}
                classes={this.props.classes}
                changeSelection={(a, b) => this.changeSelection(a, b)} />
        ) : this.state.selectedMember == null ? (
            <ClassDetails module={this.props.module}
                apiclass={this.state.selectedClass}
                changeSelection={(a, b) => this.changeSelection(a, b)} />
        ) : (
                    <MemberDetails module={this.props.module}
                        member={this.state.selectedMember}
                        apiclass={this.state.selectedClass}
                        changeSelection={(a, b) => this.changeSelection(a, b)} />
                );
        return (
            <div>
                {mainScreen}
            </div>
        );
    }
}
import * as React from 'react';
import * as Models from '../../Models/';
import ClassTree from './ClassTree';
import ClassDetails from './ClassDetails';
import MemberDetails from './MemberDetails';
import NamespaceDetails from './NamespaceDetails';
import Tree, { TreeNode, TreeNodeProps } from 'rc-tree';
import { IApiClass } from '../../../../_Development/Out/js/src/Models/index';

interface IBrowserProps {
    module: Models.IAppModule;
    selection: Models.IViewSelection;
    classes: Models.IApiClass[];
    documentationLink: string;
};

interface IBrowserState {
    selectedClass: Models.IApiClass | null;
    selectedMember: Models.IMember | null;
    selectedMemberCodeblocks: Models.IMemberCodeBlock[];
    classes: Models.IApiClass[];
    expandedNodes: string[];
};

export default class Browser extends React.Component<IBrowserProps, IBrowserState> {

    refs: {
    }

    constructor(props: IBrowserProps) {
        super(props);
        this.state = {
            selectedClass: props.selection.SelectedClass,
            selectedMember: props.selection.SelectedMember,
            selectedMemberCodeblocks: [],
            classes: props.classes,
            expandedNodes: []
        }
    }

    componentDidMount() {
        this.checkSelectedClass();
        window.onpopstate = function (e) {
            location.reload();
        }
        if (this.state.selectedMember != null) {
            this.props.module.service.getMemberCodeBlocks(this.state.selectedMember.MemberId, (data: Models.IMemberCodeBlock[]) => {
                this.setState({
                    selectedMemberCodeblocks: data
                });
            });
        }
        if (this.state.selectedClass != null) {
            this.setState({
                expandedNodes: ['c-' + this.state.selectedClass.ClassId.toString()]
            });
        }
    }

    private checkSelectedClass(): void {
        if (this.state.selectedClass) {
            this.checkClass(this.state.selectedClass);
        }
    }
    private checkClass(classToCheck: Models.IApiClass): void {
        if (classToCheck.Members == undefined) {
            this.props.module.service.getMembers(classToCheck.ClassId, (data: Models.IMember[]) => {
                var c = classToCheck;
                c.Members = data;
                var classList = this.state.classes.map(cl => {
                    return cl.ClassId == c.ClassId ? c : cl;
                });
                this.setState({
                    classes: classList
                }, () => {
                    if (this.state.selectedClass && this.state.selectedClass.ClassId == classToCheck.ClassId) {
                        this.setState({
                            selectedClass: c
                        });
                    }
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
        var codeblocks = this.state.selectedMemberCodeblocks;
        if (newMember == null && this.state.selectedMember != null) {
            codeblocks = [];
        }
        else if (newMember != null) {
            if (this.state.selectedMember == null || this.state.selectedMember.MemberId != newMember.MemberId) {
                codeblocks = [];
                this.props.module.service.getMemberCodeBlocks(newMember.MemberId, (data: Models.IMemberCodeBlock[]) => {
                    this.setState({
                        selectedMemberCodeblocks: data
                    });
                });
            }
        }
        this.setState({
            selectedClass: newClass,
            selectedMember: newMember,
            selectedMemberCodeblocks: codeblocks
        }, () => {
            this.changeUrl(this.getUrl());
            this.checkSelectedClass();
        });
    }

    private expandNode(n: string[], p: any): void {
        this.setState({ expandedNodes: n }, () => {
            for (var i = 0; i < n.length; i++) {
                var t = n[i].substring(0, 1);
                var id = parseInt(n[i].substring(2));
                switch (t) {
                    case "c":
                        for (var j = 0; j < this.state.classes.length; j++) {
                            if (this.state.classes[j].ClassId == id) {
                                this.checkClass(this.state.classes[j]);
                            }
                        }
                        break;
                }
            }
        });
    }
    private selectNode(n: any, p: any): void {
        var t = n[0].substring(0, 1);
        var id = parseInt(n[0].substring(2));
        switch (t) {
            case "n":
                this.changeSelection(null, null);
                break;
            case "c":
                for (var j = 0; j < this.state.classes.length; j++) {
                    if (this.state.classes[j].ClassId == id) {
                        this.changeSelection(this.state.classes[j], null);
                    }
                }
                break;
            case "m":
                var cl = this.state.selectedClass;
                var classId = p.node.props.classId;
                for (var j = 0; j < this.state.classes.length; j++) {
                    if (this.state.classes[j].ClassId == classId) {
                        cl = this.state.classes[j];
                    }
                }
                for (var i = 0; i < ((cl as Models.IApiClass).Members as Models.IMember[]).length; i++) {
                    var m = ((cl as Models.IApiClass).Members as Models.IMember[])[i];
                    if (m.MemberId == id) {
                        this.changeSelection(cl, m);
                    }
                }
                break;
        }
    }
    private loadTreeData(n: any): Promise<any> {
        return new Promise(resolve => {
            // do magic
            resolve();
        });
    }

    public render(): JSX.Element {
        var mainScreen = this.state.selectedClass == null ? (
            <NamespaceDetails module={this.props.module}
                namespace={this.props.selection.SelectedNamespace}
                classes={this.state.classes}
                changeSelection={(a, b) => this.changeSelection(a, b)} />
        ) : this.state.selectedMember == null ? (
            <ClassDetails module={this.props.module}
                apiclass={this.state.selectedClass}
                changeSelection={(a, b) => this.changeSelection(a, b)}
                documentationLink={this.props.documentationLink} />
        ) : (
                    <MemberDetails module={this.props.module}
                        member={this.state.selectedMember}
                        apiclass={this.state.selectedClass}
                        changeSelection={(a, b) => this.changeSelection(a, b)}
                        codeblocks={this.state.selectedMemberCodeblocks}
                        documentationLink={this.props.documentationLink} />
                );
        var classNodes = this.state.classes.map(c => {
            var subNodes: JSX.Element[] | null = null;
            if (c.Members) {
                subNodes = c.Members.map(m => {
                    return (
                        <TreeNode key={'m-' + m.MemberId.toString()}
                            title={m.MemberName}
                            isLeaf={true}
                            classId={m.ClassId}
                        >
                        </TreeNode>
                    );
                });
            }
            return (
                <TreeNode key={'c-' + c.ClassId.toString()}
                    title={c.ClassName}
                    isLeaf={false}
                >
                    {subNodes}
                </TreeNode>
            );
        });
        var selectedKeys: string[] = [];
        if (this.state.selectedClass != null) {
            if (this.state.selectedMember != null) {
                selectedKeys.push('m-' + this.state.selectedMember.MemberId.toString());
            }
            else {
                selectedKeys.push('c-' + this.state.selectedClass.ClassId.toString());
            }
        }
        return (
            <div className="row">
                <div className="col-sm-3">
                    <Tree checkable={false}
                        onSelect={(n, p) => this.selectNode(n, p)}
                        onExpand={(n, p) => this.expandNode(n, p)}
                        selectable={true}
                        multiple={false}
                        showIcon={false}
                        loadData={n => this.loadTreeData(n)}
                        selectedKeys={selectedKeys}
                        expandedKeys={this.state.expandedNodes}>
                        <TreeNode key={'n-0'}
                            title={this.props.selection.SelectedNamespace.NamespaceName}
                            isLeaf={true}
                        />
                        {classNodes}
                    </Tree>
                </div>
                <div className="col-sm-9">
                    {mainScreen}
                </div>
            </div>
        );
    }
}
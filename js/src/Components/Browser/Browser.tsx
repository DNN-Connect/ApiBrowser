import * as React from 'react';
import * as Models from '../../Models/';
import ClassList from './ClassList';
import ClassTree from './ClassTree';
import Details from './Details';

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

    public render(): JSX.Element {
        return (
            <div>{this.state.selectedClass ? this.state.selectedClass.ClassName : ""}
            </div>
        );
    }
}
import * as React from 'react';
import * as Models from '../../Models/';

interface IClassListProps {
    module: Models.IAppModule;
};

interface IClassListState {
};

export default class ClassList extends React.Component<IClassListProps, IClassListState> {

    refs: {
    }

    constructor(props: IClassListProps) {
        super(props);
        this.state = {
        }
    }

    public render(): JSX.Element {
        return (
            <div>
            </div>
        );
    }
}
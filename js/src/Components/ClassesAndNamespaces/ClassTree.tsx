import * as React from 'react';
import * as Models from '../../Models/';

interface IClassTreeProps {
    module: Models.IAppModule;
};

interface IClassTreeState {
};

export default class ClassTree extends React.Component<IClassTreeProps, IClassTreeState> {

    refs: {
    }

    constructor(props: IClassTreeProps) {
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
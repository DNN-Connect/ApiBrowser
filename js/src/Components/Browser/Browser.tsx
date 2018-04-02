import * as React from 'react';
import * as Models from '../../Models/';

interface IBrowserProps {
    module: Models.IAppModule;
    detailLink: string;
};

interface IBrowserState {
};

export default class Browser extends React.Component<IBrowserProps, IBrowserState> {

    refs: {
    }

    constructor(props: IBrowserProps) {
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
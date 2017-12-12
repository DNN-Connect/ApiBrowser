import * as React from 'react';
import * as Models from '../../Models/';

interface IDetailsProps {
    module: Models.IAppModule;
};

interface IDetailsState {
};

export default class Details extends React.Component<IDetailsProps, IDetailsState> {

    refs: {
    }

    constructor(props: IDetailsProps) {
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
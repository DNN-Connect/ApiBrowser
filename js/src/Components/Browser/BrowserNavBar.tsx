import * as React from 'react';
import * as Models from '../../Models/';

interface IBrowserNavBarProps {
    module: Models.IAppModule;
    namespace: Models.IApiNamespace;
    classes: Models.IApiClass[];
};

export default class BrowserNavBar extends React.Component<IBrowserNavBarProps> {
    public render(): JSX.Element {
        return (
            <div className="sidebar">
            <nav role="navigation" className="sidebar-nav">
            </nav>
            </div>
        );
    }
}
import * as React from 'react';
import * as Models from '../../Models/';

interface INamespaceDetailsProps {
    module: Models.IAppModule;
    namespace: Models.IApiNamespace;
    classes: Models.IApiClass[];
    changeSelection: (newClass: Models.IApiClass | null, newMember: Models.IMember | null) => void;
};

export default class NamespaceDetails extends React.Component<INamespaceDetailsProps> {
    public render(): JSX.Element {
        var classRows = this.props.classes.map(c => {
            var warning = null;
            if (c.IsDeprecated) {
                warning = (<span className="redhighlight">Deprecated</span>);
            }
            if (c.DisappearedInVersion) {
                warning = (<span className="redhighlight">Removed</span>);
            }
            return (
                <tr key={c.ClassId}>
                    <td>
                        <a href="#" onClick={e => { e.preventDefault(); this.props.changeSelection(c, null) }}>{c.ClassName}</a>
                        {warning}
                    </td>
                    <td>{c.Description}</td>
                </tr>
            );
        });
        return (
            <div className="content">
                <h2>{this.props.namespace.NamespaceName} Namespace</h2>
                <p>{this.props.namespace.Description}</p>
                <h3>{this.props.module.resources.Classes}</h3>
                <table>
                    <tbody>
                        {classRows}
                    </tbody>
                </table>
            </div>
        );
    }
}
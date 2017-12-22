import * as React from 'react';
import * as Models from '../../Models/';
import ModerationRow from './ModerationRow';
import Compare from './Compare';

interface IModerationScreenProps {
    module: Models.IAppModule;
    documentationLink: string;
};

interface IModerationScreenState {
    moderationList: Models.IModerationItem[];
};

export default class ModerationScreen extends React.Component<IModerationScreenProps, IModerationScreenState> {

    refs: {
        compare: Compare
    }

    constructor(props: IModerationScreenProps) {
        super(props);
        this.state = {
            moderationList: []
        }
    }

    componentDidMount() {
        this.props.module.service.getModerationItems((data: Models.IModerationItem[]) => {
            this.setState({
                moderationList: data
            });
        });
    }

    private showItem(item: Models.IModerationItem): void {
        this.refs.compare.show(item);
    }

    private acceptChange(item: Models.IModerationItem): void {
        switch (item.DocType) {
            case 0: // class description
                this.props.module.service.approveClassDescription(item.ClassId, () => {
                    this.remove(item);
                });
                break;
            case 1: // member description
                this.props.module.service.approveMemberDescription(item.MemberId, () => {
                    this.remove(item);
                });
                break;
            case 2: // documentation
                this.props.module.service.setCurrentVersion(item.DocumentationId, () => {
                    this.remove(item);
                });
                break;
        }
    }

    private rejectChange(item: Models.IModerationItem): void {
        switch (item.DocType) {
            case 0: // class description
                this.props.module.service.rejectClassDescription(item.ClassId, () => {
                    this.remove(item);
                });
                break;
            case 1: // member description
                this.props.module.service.rejectMemberDescription(item.MemberId, () => {
                    this.remove(item);
                });
                break;
            case 2: // documentation
                break;
        }
    }

    private remove(item: Models.IModerationItem): void {
        var newList: Models.IModerationItem[] = [];
        for (var i = 0; i < this.state.moderationList.length; i++) {
            if (JSON.stringify(this.state.moderationList[i]) !== JSON.stringify(item)) {
                newList.push(this.state.moderationList[i]);
            }
        }
        this.setState({
            moderationList: newList
        });
    }

    public render(): JSX.Element {
        var i = 0;
        var rows = this.state.moderationList.map(m => {
            i++;
            return <ModerationRow key={i} module={this.props.module} item={m}
                showItem={a => this.showItem(a)}
                documentationLink={this.props.documentationLink} />
        });
        return (
            <div>
                <table className="table">
                    <thead>
                        <tr>
                            <th>{this.props.module.resources.Item}</th>
                            <th>{this.props.module.resources.By}</th>
                            <th>{this.props.module.resources.At}</th>
                            <th>{this.props.module.resources.Current}</th>
                            <th>{this.props.module.resources.Proposed}</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {rows}
                    </tbody>
                </table>
                <Compare module={this.props.module} ref="compare"
                    acceptChange={a => this.acceptChange(a)}
                    rejectChange={a => this.rejectChange(a)} />
            </div>
        );
    }
}
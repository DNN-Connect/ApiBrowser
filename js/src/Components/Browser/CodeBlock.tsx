import * as React from "react";
import * as Models from "../../Models/";

interface ICodeBlockProps {
  module: Models.IAppModule;
}

interface ICodeBlockState {
  contents: Models.ICodeBlock | null;
}

declare var hljs: any;

export default class CodeBlock extends React.Component<
  ICodeBlockProps,
  ICodeBlockState
> {
  refs: {
    codeblock: HTMLElement;
  };

  constructor(props: ICodeBlockProps) {
    super(props);
    this.state = {
      contents: null
    };
  }

  public show(codeblockId: number): void {
    this.props.module.service.getCodeblock(
      codeblockId,
      (data: Models.ICodeBlock) => {
        this.setState(
          {
            contents: data
          },
          () => {
            hljs.highlightBlock(this.refs.codeblock);
          }
        );
      }
    );
  }

  public render(): JSX.Element {
    return (
      <pre>
        <code className="cs" ref="codeblock">
          {this.state.contents ? this.state.contents.Body : ""}
        </code>
      </pre>
    );
  }
}

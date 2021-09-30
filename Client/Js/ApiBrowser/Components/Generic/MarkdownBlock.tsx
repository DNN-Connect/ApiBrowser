import {
  createSignal,
  Component,
  createEffect,
  For,
  onCleanup,
} from "solid-js";
import marked from "marked";

interface IMarkdownBlockProps {
  source: string;
}

const MarkdownBlock: Component<IMarkdownBlockProps> = (props) => {
  return <div innerHTML={marked(props.source)}></div>;
};

export default MarkdownBlock;

export interface ITreeviewNode {
    text: string;
    nodes: ITreeviewNode[] | undefined;
}

export class TreeviewNode implements ITreeviewNode {
    text: string;
    nodes: ITreeviewNode[] | undefined;
    constructor(title: string) {
        this.text = title;
    }    
}
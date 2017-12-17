import * as Models from './Models/';

export interface DnnServiceFramework extends JQueryStatic {
    dnnSF(moduleId: number): DnnServiceFramework;
    getServiceRoot(path: string): string;
    setModuleHeaders(): void;
}

export default class DataService {
    private moduleId: number = -1;
    private dnn: DnnServiceFramework = <DnnServiceFramework>$;
    private baseServicepath: string = this.dnn.dnnSF(this.moduleId).getServiceRoot('Connect/ApiBrowser');
    constructor(mid: number) {
        this.moduleId = mid;
    };
    private ajaxCall(type: string, servicePath: string, controller: string, action: string, id: any, data: any, success: Function, fail?: Function)
        : void {
        $.ajax({
            type: type,
            url: servicePath + controller + '/' + action + (id != undefined
                ? '/' + id
                : ''),
            beforeSend: this
                .dnn
                .dnnSF(this.moduleId)
                .setModuleHeaders,
            data: data
        })
            .done(function (retdata: any) {
                if (success != undefined) {
                    success(retdata);
                }
            })
            .fail(function (xhr: any, status: any) {
                if (fail != undefined) {
                    fail(xhr.responseText);
                }
            });
    };
    public deleteDocumentation(docid: number, success: Function): any {
        this.ajaxCall('POST', this.baseServicepath, 'Documentations', 'Delete', docid, null, success)
    }
    public getAll(classes: boolean, namespaces: boolean, searchText: string, pageIndex: number, pageSize: number, success: Function): any {
        this.ajaxCall('GET', this.baseServicepath, 'NamespacesAndClasses', 'List', null, { classes: classes, namespaces: namespaces, searchText: searchText, pageIndex: pageIndex, pageSize: pageSize }, success)
    }
    public getCodeblock(codeblockId: number, success: Function): any {
        this.ajaxCall('GET', this.baseServicepath, 'MemberCodeBlocks', 'Get', codeblockId, null, success)
    }
    public getMemberCodeBlocks(memberId: number, success: Function): any {
        this.ajaxCall('GET', this.baseServicepath, 'Members', 'Codeblocks', memberId, null, success)
    }
    public getMembers(classId: number, success: Function): any {
        this.ajaxCall('GET', this.baseServicepath, 'ApiClasses', 'Members', classId, null, success)
    }
    public getScheduledFiles(success: Function): any {
        this.ajaxCall('GET', this.baseServicepath, 'Files', 'Files', null, null, success)
    }
    public processFiles(success: Function): any {
        this.ajaxCall('POST', this.baseServicepath, 'Files', 'Process', null, null, success)
    }
    public saveDocumentation(documentation: Models.IDocumentation, success: Function): any {
        this.ajaxCall('POST', this.baseServicepath, 'Documentations', 'Save', null, documentation, success)
    }
    public setCurrentVersion(docid: number, success: Function): any {
        this.ajaxCall('POST', this.baseServicepath, 'Documentations', 'SetCurrent', docid, null, success)
    }
    public postFiles(files: any, success: Function, fail?: Function) {
        var data = new FormData();
        $.each(files, function (key, value) {
            data.append(key, value);
        });
        //this.showLoading();
        var that = this;
        $.ajax({
            type: "POST",
            url: that.baseServicepath + 'Files/Upload',
            beforeSend: that
                .dnn
                .dnnSF(that.moduleId)
                .setModuleHeaders,
            data: data,
            cache: false,
            dataType: 'json',
            processData: false,
            contentType: false
        }).done(function (retdata) {
            //that.hideLoading();
            if (success != undefined) {
                success(retdata);
            }
        }).fail(function (xhr, status) {
            //that.hideLoading();
            //that.showError(xhr.responseText);
            if (fail != undefined) {
                fail(xhr.responseText);
            }
        });
    }
}

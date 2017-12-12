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
    public getMembers(classId: number, success: Function): any {
        this.ajaxCall('GET', this.baseServicepath, 'ApiClasses', 'Members', classId, null, success)        
    }
}

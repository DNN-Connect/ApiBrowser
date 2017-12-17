import DataService from "../Service";
import { IContextSecurity } from "./index";

export interface IAppModule {
    moduleId: number;
    tabId: number;
    locale: string;
    resources: any;
    security: IContextSecurity;
    service: DataService;
}

export class AppModule implements IAppModule {
    public moduleId: number;
    public tabId: number;
    public locale: string;
    public resources: any;
    public security: IContextSecurity;
    public service: DataService;
    constructor(moduleId: number, tabId: number, locale: string, resources: any, security: any, service: DataService) {
        this.moduleId = moduleId;
        this.tabId = tabId;
        this.locale = locale;
        this.resources = resources;
        this.security = security;
        this.service = service;
    }
}

import { resource, ResourceRef, ResourceStatus, Signal } from "@angular/core";
import { environment } from "../../../../environments/environment";
import { GenericsAllInterface } from "./generics-all.interface";
import { GenericsShared } from "../shared/generics-shared.interface";

const api: string = environment.endpoint;

export abstract class GenericsAllClass<T> implements GenericsAllInterface<T>, GenericsShared {

    constructor(
        protected controller: string
    ) {}

    getAllResource: ResourceRef<T[]> = resource({
        loader: async () => {
            const response = await fetch(
                `${api}${this.controller}/GetAll`, 
                {
                    headers: {"Content-Type": "application/json"}
                });
            return await response.json() as T[]
        }
    });
    
    data: Signal<T[] | undefined> = this.getAllResource.value;
    isLoading: Signal<boolean> = this.getAllResource.isLoading;
    error: Signal<any> = this.getAllResource.error;
    status: Signal<ResourceStatus> = this.getAllResource.status;

    reload(): void {
        this.getAllResource.reload();
    }

    destroyResource(): void {
        this.getAllResource.destroy();
    }

}
import { resource, ResourceRef, ResourceStatus, Signal, signal, WritableSignal } from "@angular/core";
import { GenericsShared } from "../shared/generics-shared.interface";
import { GenericsCreateInterface } from "./generics-create.interface";
import { environment } from "../../../../environments/environment";

const api: string = environment.endpoint;

export abstract class GenericsCreateClass<T> implements GenericsCreateInterface<T>, GenericsShared {

    constructor(
        protected controller: string
    ) {}

    entity: WritableSignal<T | undefined> = signal(undefined);

    createResource: ResourceRef<boolean | undefined> = resource({
        request: this.entity,
        loader: async () => {
            if(this.entity()) {
                const response = await fetch(
                    `${api}${this.controller}/Create`,
                    {
                        method: 'POST',
                        body: JSON.stringify(this.entity()),
                        headers: {"Content-Type": "application/json"}
                    }
                );
                    
                return await response.ok ? true : false;
            } 
        
            return undefined;   
        }
    });

    data: WritableSignal<boolean | undefined> = this.createResource.value;
    isLoading: Signal<boolean> = this.createResource.isLoading;
    error: Signal<any> = this.createResource.error;
    status: Signal<ResourceStatus> = this.createResource.status;
    
    onChangeEntity(entity: T): void {
        this.entity.set(entity);
    }

    destroyResource(): void {
        this.createResource.destroy();
    }

}
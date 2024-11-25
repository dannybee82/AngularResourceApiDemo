import { resource, ResourceRef, Signal, signal, WritableSignal } from "@angular/core";
import { environment } from "../../../../environments/environment";
import { GenericsShared } from "../shared/generics-shared.interface";
import { GenericsUpdateInterface } from "./generics-update.interface";

const api: string = environment.endpoint;

export abstract class GenericsUpdateClass<T> implements GenericsUpdateInterface<T>, GenericsShared {

    constructor(
        protected controller: string
    ) {}

    entity: WritableSignal<T | undefined> = signal(undefined);

    updateResource: ResourceRef<boolean | undefined> = resource({
        request: this.entity,
        loader: async () => {
            if(this.entity()) {
                const response = await fetch(
                    `${api}${this.controller}/Update`,
                    {
                        method: 'PUT',
                        body: JSON.stringify(this.entity()),
                        headers: {"Content-Type": "application/json"}
                    }
                );
                    
                return await response.ok ? true : false;
            } 
        
            return undefined;   
        }
    });

    data: WritableSignal<boolean | undefined> = this.updateResource.value;
    isLoading: Signal<boolean> = this.updateResource.isLoading;
    error: Signal<any> = this.updateResource.error;

    onChangeEntity(entity: T): void {
        this.entity.set(entity);
    }

}
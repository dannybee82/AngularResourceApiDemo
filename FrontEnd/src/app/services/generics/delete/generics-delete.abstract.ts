import { GenericsDeleteInterface } from "./generics-delete.interface";
import { GenericsShared } from "../shared/generics-shared.interface";
import { environment } from "../../../../environments/environment";
import { resource, ResourceRef, Signal, signal, WritableSignal } from "@angular/core";

const api: string = environment.endpoint;

export class GenericsDeleteClass<T> implements GenericsDeleteInterface<T>, GenericsShared {
    
    constructor(
        protected controller: string
    ) {}

    targetId: WritableSignal<number> = signal(0);

    deleteResource: ResourceRef<boolean | undefined> = resource({
        request: this.targetId,
        loader: async (params) => {
          const id: number = params.request;
    
          if(id > 0) {
            const response = await fetch(
              `${api}${this.controller}/Delete?id=${id}`,
              {
                method: 'DELETE',  
                headers: {"Content-Type": "application/json"}
              } 
            );
            return await response.ok ? true : false;
          }
          
          return undefined;
        }        
    });

    data: WritableSignal<boolean | undefined> = this.deleteResource.value;
    isLoading: Signal<boolean> = this.deleteResource.isLoading;
    error: Signal<any> = this.deleteResource.error;

    onTargetIdChange(id: number): void {
        this.targetId.set(id);
    }

}
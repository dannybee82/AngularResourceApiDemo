import { resource, ResourceRef, ResourceStatus, Signal, signal, WritableSignal } from "@angular/core";
import { GenericsByIdInterface } from "./generics-by-id.interface";
import { environment } from "../../../../environments/environment";
import { GenericsShared } from "../shared/generics-shared.interface";

const api: string = environment.endpoint;

export abstract class GenericsByIdClass<T> implements GenericsByIdInterface<T>, GenericsShared {

    constructor(
        protected controller: string
    ) {}

    targetId: WritableSignal<number> = signal(0);

    getByIdResource: ResourceRef<T | undefined> = resource({
        request: this.targetId,
        loader: async (params) => {
          const id: number = params.request;
    
          if(id > 0) {
            const response = await fetch(
                `${api}${this.controller}/GetById?id=${id}`, 
                {
                    signal: params.abortSignal, 
                    headers: {"Content-Type": "application/json"}
                }
            );
            return await response.json() as T;
          }
          
          return undefined;
        }
      });

    data: Signal<T | undefined> = this.getByIdResource.value;
    isLoading: Signal<boolean> = this.getByIdResource.isLoading;
    error: Signal<any> = this.getByIdResource.error;
    status: Signal<ResourceStatus> = this.getByIdResource.status;
 
    reload(): void {
      this.getByIdResource.reload();
    }

    onTargetIdChange(id: number): void {
      this.targetId.set(id);
    }

    destroyResource(): void {
      this.getByIdResource.destroy();
    }

}
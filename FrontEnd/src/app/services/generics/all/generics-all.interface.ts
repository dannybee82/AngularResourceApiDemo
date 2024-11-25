import { ResourceRef, Signal } from "@angular/core";

export interface GenericsAllInterface<T> {
    getAllResource: ResourceRef<T[]>;
   
    data: Signal<T[] | undefined>    

    reload(): void;
}
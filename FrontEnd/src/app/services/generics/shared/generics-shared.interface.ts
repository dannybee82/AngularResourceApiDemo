import { Signal } from "@angular/core";

export interface GenericsShared {
    isLoading: Signal<boolean>;
    
    error: Signal<any>;
}
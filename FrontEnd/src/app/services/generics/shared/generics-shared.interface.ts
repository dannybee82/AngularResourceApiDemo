import { ResourceStatus, Signal } from "@angular/core";

export interface GenericsShared {
    isLoading: Signal<boolean>;
    
    error: Signal<any>;

    status: Signal<ResourceStatus>;

    destroyResource(): void;
}
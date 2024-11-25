import { ResourceRef, WritableSignal } from "@angular/core";

export interface GenericsDeleteInterface<T> {
    targetId: WritableSignal<number>;

    deleteResource: ResourceRef<boolean | undefined>;

    data: WritableSignal<boolean | undefined>;

    onTargetIdChange(id: number): void;
}
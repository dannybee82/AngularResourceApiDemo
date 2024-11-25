import { Injectable } from '@angular/core';
import { Book } from '../../models/book.interface';
import { GenericsUpdateClass } from '../generics/update/generics-update.abstract';

@Injectable({
  providedIn: 'root'
})
export class UpdateBookService extends GenericsUpdateClass<Book> {

  constructor() {
    super('Book');
  }

}

// export class UpdateBookService {

//   protected bookEntity: WritableSignal<Book | undefined> = signal(undefined);

//   protected updateBookResource: ResourceRef<boolean> = resource({
//     request: this.bookEntity,
//     loader: async () => {
//       if(this.bookEntity()) {
//         const response = await fetch(
//           `${api}Book/UpdateBook`,
//           {
//             method: 'PUT',
//             body: JSON.stringify(this.bookEntity()),
//             headers: {"Content-Type": "application/json"}
//           }
//         );

//         return await response.ok ? true : false;
//       } 
      
//       return false;   
//     }
//   });
  
//   isLoading: Signal<boolean> = this.updateBookResource.isLoading;
//   isUpdated: WritableSignal<boolean | undefined> = this.updateBookResource.value;
//   error: Signal<any> = this.updateBookResource.error;

//   onChangeBookEntity(entity: Book): void {
//     this.bookEntity.set(entity);
//   }

// }
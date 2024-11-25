import { Injectable } from '@angular/core';
import { Book } from '../../models/book.interface';
import { GenericsCreateClass } from '../generics/create/generics-create.abstract';

@Injectable({
  providedIn: 'root'
})
export class CreateBookService extends GenericsCreateClass<Book> {

  constructor() {
    super('Book');
  }

}
// export class CreateBookService {

//   protected bookEntity: WritableSignal<Book | undefined> = signal(undefined);

//   protected createBookResource: ResourceRef<boolean> = resource({
//     request: this.bookEntity,
//     loader: async () => {
//       if(this.bookEntity()) {
//         const response = await fetch(
//           `${api}Book/CreateBook`,
//           {
//             method: 'POST',
//             body: JSON.stringify(this.bookEntity()),
//             headers: {"Content-Type": "application/json"}
//           }
//         );

//         return await response.ok ? true : false;
//       } 
      
//       return false;   
//     }
//   });
  
//   isLoading: Signal<boolean> = this.createBookResource.isLoading;
//   isCreated: WritableSignal<boolean | undefined> = this.createBookResource.value;
//   error: Signal<any> = this.createBookResource.error;

//   onChangeBookEntity(entity: Book): void {
//     this.bookEntity.set(entity);
//   }

// }
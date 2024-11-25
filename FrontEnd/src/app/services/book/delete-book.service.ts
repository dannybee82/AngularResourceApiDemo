import { Injectable } from '@angular/core';
import { Book } from '../../models/book.interface';
import { GenericsDeleteClass } from '../generics/delete/generics-delete.abstract';

@Injectable({
  providedIn: 'root'
})
export class DeleteBookService extends GenericsDeleteClass<Book> {

  constructor() {
    super('Book');
  }

}

// export class DeleteBookService {

//   protected deleteBookId: WritableSignal<number> = signal<number>(0);

//   protected bookDeleteResource: ResourceRef<boolean | undefined> = resource({
//     request: this.deleteBookId,
//     loader: async (params) => {
//       const bookId: number = params.request;

//       if(bookId > 0) {
//         const response = await fetch(
//           `${api}Book/DeleteBook?id=${bookId}`, 
//           {
//             method: 'DELETE',  
//             headers: {"Content-Type": "application/json"}
//           } 
//         );
//         return await response.ok ? true : false;
//       }
      
//       return undefined;
//     }
//   })

//   isLoading: Signal<boolean> = this.bookDeleteResource.isLoading;
//   isDeleted: WritableSignal<boolean | undefined> = this.bookDeleteResource.value;
//   error: Signal<any> = this.bookDeleteResource.error;

//   changeDeleteBookId(bookId: number): void {
//     this.deleteBookId.set(bookId);
//   }

// }
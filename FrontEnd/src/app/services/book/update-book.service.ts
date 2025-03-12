import { Injectable } from '@angular/core';
import { Book } from '../../models/book.interface';
import { GenericsUpdateClass } from '../generics/update/generics-update.abstract';

@Injectable({
  providedIn: 'root'
})
export class UpdateBookService extends GenericsUpdateClass<Book> {

  constructor() {
    super('Book', 'Update');
  }

}
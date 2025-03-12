import { Injectable } from '@angular/core';
import { Book } from '../../models/book.interface';
import { GenericsCreateClass } from '../generics/create/generics-create.abstract';

@Injectable({
  providedIn: 'root'
})
export class CreateBookService extends GenericsCreateClass<Book> {

  constructor() {
    super('Book', 'Create');
  }

}
import { Injectable } from '@angular/core';
import { Book } from '../../models/book.interface';
import { GenericsDeleteClass } from '../generics/delete/generics-delete.abstract';

@Injectable({
  providedIn: 'root'
})
export class DeleteBookService extends GenericsDeleteClass<Book> {

  constructor() {
    super('Book', 'Delete');
  }

}
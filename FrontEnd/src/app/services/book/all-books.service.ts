import { Injectable } from '@angular/core';
import { Book } from '../../models/book.interface';
import { GenericsAllClass } from '../generics/all/generics-all.abstract';

@Injectable({
  providedIn: 'root'
})
export class AllBooksService extends GenericsAllClass<Book> {

  constructor() {
    super('Book', 'GetAll', []);
  }

}
import { Injectable } from '@angular/core';
import { Book } from '../../models/book.interface';
import { GenericsByIdClass } from '../generics/by_id/generics-by-id.abstract';

@Injectable({
  providedIn: 'root'
})
export class BookDetailsService extends GenericsByIdClass<Book> {

  constructor() {
    super('Book', 'GetById');
  }

}
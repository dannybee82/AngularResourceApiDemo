import { Component, OnInit, inject } from '@angular/core';
import { AllMaterialsModule } from '../../all-materials-module.module';
import { RouterModule } from '@angular/router';
import { FullnamePipe } from '../../custom_pipes/fullname.pipe';
import { GenericsAllClass } from '../../services/generics/all/generics-all.abstract';
import { Book } from '../../models/book.interface';

@Component({
  selector: 'app-all-books',
  imports: [
    FullnamePipe,
    AllMaterialsModule,
    RouterModule
  ],
  templateUrl: './all-books.component.html',
  styleUrl: './all-books.component.scss'
})
export class AllBooksComponent extends GenericsAllClass<Book> implements OnInit {

  constructor(){
    super('Book', 'GetAll', []);
  }

  ngOnInit(): void {
    if(this.data()) {
      this.reload();
    }
  }

}
import { Component, OnInit, inject } from '@angular/core';
import { AllMaterialsModule } from '../../all-materials-module.module';
import { RouterModule } from '@angular/router';
import { AllBooksService } from '../../services/book/all-books.service';
import { FullnamePipe } from '../../custom_pipes/fullname.pipe';

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
export class AllBooksComponent implements OnInit {

  private allBooksService = inject(AllBooksService);

  ngOnInit(): void {
    if(this.service().data()) {
      this.service().reload();
    }
  }

  service(): AllBooksService {
    return this.allBooksService;
  }

}
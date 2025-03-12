import { Component, EffectRef, InputSignal, OnDestroy, OnInit, WritableSignal, effect, inject, input, signal } from '@angular/core';
import { AllMaterialsModule } from '../../all-materials-module.module';
import { FullnamePipe } from '../../custom_pipes/fullname.pipe';
import { DatePipe } from '@angular/common';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogData } from '../../models/confirmation-dialog-data.interface';
import { Book } from '../../models/book.interface';
import { EMPTY, of, switchMap } from 'rxjs';
import { DeleteBookService } from '../../services/book/delete-book.service';
import { Router, RouterModule } from '@angular/router';
import { GenericsByIdClass } from '../../services/generics/by_id/generics-by-id.abstract';

@Component({
  selector: 'app-book-details',
  imports: [
    AllMaterialsModule,    
    DatePipe,
    RouterModule,
    FullnamePipe
  ],
  templateUrl: './book-details.component.html',
  styleUrl: './book-details.component.scss'
})
export class BookDetailsComponent extends GenericsByIdClass<Book> implements OnInit, OnDestroy {

  bookId: InputSignal<number> = input.required<number>();
  errorMessage: WritableSignal<string> = signal('');

  bookDeletedEffect: EffectRef = effect(() => {
    if(this.deleteBookService.data()) {      
      this.router.navigate(['/all-books']);
    }

    if(this.deleteBookService.error()) {
      this.errorMessage.set("Can't delete Book.");
    }
  });

  private deleteBookService = inject(DeleteBookService);
  private router = inject(Router);
  public dialog = inject(MatDialog);
  
  constructor() {
    super('Book', 'GetById');
  }

  ngOnInit(): void {
    if(this.bookId() > 0 && !isNaN(this.bookId())) {
      this.onTargetIdChange(this.bookId());     
    } else {
      this.errorMessage.set("Can't get Book by id.");
    }
  }

  ngOnDestroy(): void {
    this.deleteBookService.data.set(undefined);
  }

  showDialog(): void {
    const book: Book | undefined = this.data();

    let additionalInfo: string = '';
    
    if(book) {
      additionalInfo = book.title
    }

    const data: ConfirmationDialogData = {
      dialogTitle: 'Delete Book',
      dialogMessage: 'Do you really want to delete this book: ' + additionalInfo + "?",
      cancelText: 'Cancel',
      confirmText: 'Delete'
    };

    const dialog = this.dialog.open(ConfirmationDialogComponent, {data});

    dialog.afterClosed().pipe(
      switchMap((data) => {
        if(data) {
          if(data.dialogResult === true) {
            return of(true);
          }          
        }

        return EMPTY;
      })
    ).subscribe((confirmation: boolean) => {
      if(confirmation) {
        this.deleteBookService.onTargetIdChange(this.bookId());
      }      
    });
  }

}
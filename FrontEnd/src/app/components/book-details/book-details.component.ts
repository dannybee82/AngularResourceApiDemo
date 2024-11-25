import { Component, InputSignal, OnDestroy, OnInit, WritableSignal, effect, inject, input, signal } from '@angular/core';
import { AllMaterialsModule } from '../../all-materials-module.module';
import { FullnamePipe } from '../../custom_pipes/fullname.pipe';
import { DatePipe } from '@angular/common';
import { BookDetailsService } from '../../services/book/book-details.service';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogData } from '../../models/confirmation-dialog-data.interface';
import { Book } from '../../models/book.interface';
import { EMPTY, of, switchMap } from 'rxjs';
import { DeleteBookService } from '../../services/book/delete-book.service';
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';

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
export class BookDetailsComponent implements OnInit, OnDestroy {

  bookId: InputSignal<number> = input.required<number>();
  errorMessage: WritableSignal<string> = signal('');

  bookDeletedEffect = effect(() => {
    if(this.deleteBookService.data()) {      
      this.router.navigate(['/all-books']);
    }

    if(this.deleteBookService.error()) {
      this.errorMessage.set("Can't delete Book.");
    }
  });

  private bookDetailsService = inject(BookDetailsService);
  private deleteBookService = inject(DeleteBookService);
  private router = inject(Router);
  public dialog = inject(MatDialog);
  
  ngOnInit(): void {
    if(this.bookId() > 0 && !isNaN(this.bookId())) {
      this.bookDetailsService.onTargetIdChange(this.bookId());     
    } else {
      this.errorMessage.set("Can't get Book by id.");
    }
  }

  ngOnDestroy(): void {
    this.deleteBookService.data.set(undefined);
  }

  service(): BookDetailsService {
    return this.bookDetailsService;
  }

  showDialog(): void {
    const book: Book | undefined = this.service().data();

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
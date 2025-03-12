import { Component, effect, EffectRef, inject, input, InputSignal, OnInit, signal, WritableSignal } from '@angular/core';
import { CreateBookService } from '../../services/book/create-book.service';
import { FormBuilder, FormGroup, UntypedFormGroup, Validators } from '@angular/forms';
import { BookDetailsService } from '../../services/book/book-details.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AllMaterialsModule } from '../../all-materials-module.module';
import { Author } from '../../models/author.interface';
import { Router } from '@angular/router';
import { ValidateDate } from '../../functions/validate-date.validator';
import { ReformatDates } from '../../functions/reformat-dates';
import { Book } from '../../models/book.interface';
import { UpdateBookService } from '../../services/book/update-book.service';
import { Publisher } from '../../models/publisher.interface';

@Component({
  selector: 'app-create-or-update-book',
  imports: [
    FormsModule, 
    ReactiveFormsModule, 
    AllMaterialsModule
  ],
  templateUrl: './create-or-update-book.component.html',
  styleUrl: './create-or-update-book.component.scss'
})
export class CreateOrUpdateBookComponent implements OnInit {

  bookId: InputSignal<number> = input.required<number>();  
  private _updateBook: WritableSignal<Book | undefined> = signal(undefined);

  isUpdateMode: WritableSignal<boolean> = signal(false);
  
  updateFormsEffect: EffectRef = effect(() => {
    if(this.isUpdateMode() && this.bookService().data()) {
      const book: Book | undefined = this.bookService().data();

      if(book) {
        this._updateBook.set(book);
        
        this.bookForm.patchValue(book);

        if(book.author) {
          this.authorForm.patchValue(book.author);
          this.authorForm.controls['dayOfBirth'].setValue(this._reformatDates.reformatDateForForms(book.author.dayOfBirth, true));
        }
        
        if(book.publisher) {
          this.publisherForm.patchValue(book.publisher);
        }
      } else {
        this.errorMessage.set("Can't get Book by id.");
      }
    }
  });

  creatingBookFinished = effect(() => {
    if(this.create().data()) {
      this.router.navigate(['/all-books']);
    }

    if(this.create().error()) {      
      this.errorMessage.set("Can't create new Book.");
    }
  });

  updatingBookFinished = effect(() => {
    if(this.update().data()) {
      this.bookService().reload();
      this.router.navigate(['/book-details', this.bookId()]);
    }

    if(this.update().error()) {
      this.errorMessage.set("Can't update Book.");
    }
  });
  
  errorMessage: WritableSignal<string> = signal('');

  bookForm: UntypedFormGroup = new FormGroup({});
  authorForm: UntypedFormGroup = new FormGroup({});
  publisherForm: UntypedFormGroup = new FormGroup({});

  bookFormFields: Map<string, string> = new Map<string, string>([
    ["title", "Book Title"],
    ["description", "Book description"],
    ["isbn", "ISBN Number"]
  ]);

  authorFormFields: Map<string, string> = new Map<string, string>([
    ["firstName", "Firstname"],
    ["middleName", "Middlename"],
    ["lastName", "Lastname"],
    ["dayOfBirth", "Day of Birth (dd-mm-yyyy)"],
  ]);

  publisherFormFields: Map<string, string> = new Map<string, string>([
    ["name", "Publisher name"],
  ]);

  private _reformatDates: ReformatDates = new ReformatDates();

  private createBookService = inject(CreateBookService);
  private updateBookService = inject(UpdateBookService);
  private bookDetailsService = inject(BookDetailsService);
  private fb = inject(FormBuilder);
  private router = inject(Router);

  ngOnInit(): void {
    this.bookForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      isbn: ['', Validators.required],
    });

    this.authorForm = this.fb.group({
    	firstName: ['', Validators.required],
	    middleName: [''],
      lastName: ['', Validators.required],
      dayOfBirth: ['', [Validators.required, ValidateDate.validateDate]],
    });

    this.publisherForm = this.fb.group({
      name: ['', Validators.required],
    });

    if(this.bookId() > 0 && !isNaN(this.bookId())) {
      //Update mode.
      this.isUpdateMode.set(true);
      this.bookDetailsService.onTargetIdChange(this.bookId());
    }
  }

  ngOnDestroy(): void {
    this.create().data.set(undefined);
    this.update().data.set(undefined);   
  }

  bookService(): BookDetailsService {
    return this.bookDetailsService;
  }

  create(): CreateBookService {
    return this.createBookService;
  }

  update(): UpdateBookService {
    return this.updateBookService;
  }

  submit(): void {
    if(this.bookForm.valid && this.authorForm.valid && this.publisherForm.valid) {
      if(this.isUpdateMode()) {
        //Update
        this.updateBookService.onChangeEntity(this.assignValues());
      } else {
        //Create
        this.createBookService.onChangeEntity(this.assignValues());
      }      
    } else {
      this.bookForm.markAllAsTouched();
      this.authorForm.markAllAsTouched();
      this.publisherForm.markAllAsTouched();
    }
  }

  private assignValues(): Book  {
    const author: Author = Object.assign(this.authorForm.value);
    author.dayOfBirth = this._reformatDates.formatDateToString(this.authorForm.controls['dayOfBirth'].value, false);
    const publisher: Publisher = Object.assign(this.publisherForm.value);
    const book: Book = Object.assign(this.bookForm.value);

    book.author = author;
    book.publisher = publisher;
    book.dateCreated = new Date().toJSON();

    if(this.isUpdateMode() && this._updateBook()) {
      book.id = this._updateBook()?.id;
      book.author.id = this._updateBook()?.author?.id;
      book.publisher.id = this._updateBook()?.publisher?.id;
    }

    return book;
  }

}
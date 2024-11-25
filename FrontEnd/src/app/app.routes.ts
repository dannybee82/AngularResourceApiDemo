import { Routes } from '@angular/router';
import { MenuComponent } from './components/menu/menu.component';

export const routes: Routes = [
    {
        path: '',
        component: MenuComponent,
        children: [
            {
                path: 'all-books',
                loadComponent: () => import('../../src/app/components/all-books/all-books.component').then(c => c.AllBooksComponent)
            },
            {
                path: 'book-details/:bookId',
                loadComponent: () => import('../../src/app/components/book-details/book-details.component').then(c => c.BookDetailsComponent)
            },
            {
                path: 'create-book',
                loadComponent: () => import('../../src/app/components/create-or-update-book/create-or-update-book.component').then(c => c.CreateOrUpdateBookComponent)
            },
            {
                path: 'update-book/:bookId',
                loadComponent: () => import('../../src/app/components/create-or-update-book/create-or-update-book.component').then(c => c.CreateOrUpdateBookComponent)
            }
        ]
    }    
];

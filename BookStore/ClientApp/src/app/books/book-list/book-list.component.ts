import { Component, ViewChild, ElementRef } from '@angular/core';
import { Book } from '../book/book.model';
import { DetailPopupComponent } from '../../detail-popup/detail-popup.component';
import { MatDialog } from '@angular/material/dialog';
import { PageEvent, MatPaginator } from '@angular/material/paginator';
import { BookService } from './book-list.service';
import { fromEvent } from 'rxjs';
import {
  debounceTime,
  map,
  distinctUntilChanged
} from "rxjs/operators";

@Component({
  selector: 'book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent {

  defaultPageIndex: number = 0;
  defaultPageSize: number = 6;
  searchTerm: string = null;
  pageEvent: PageEvent;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('searchTermInput') searchTermInput: ElementRef;
  books: Array<Book>;

  constructor(private bookService: BookService, private dialog: MatDialog) { }

  ngOnInit() {
    this.loadData();
  }

  ngAfterViewInit() {
    fromEvent(this.searchTermInput.nativeElement, 'keyup').pipe(

      // get value
      map((event: any) => {
        return event.target.value;
      })
      // Time in milliseconds between key events
      , debounceTime(1000)

      // If previous query is diffent from current   
      , distinctUntilChanged()

      // subscription for response
    ).subscribe((text: string) => {
      this.loadData(text);
    });
  }

  loadData(searchTerm: string = null) {
    this.pageEvent = new PageEvent();
    this.pageEvent.pageIndex = this.defaultPageIndex;
    this.pageEvent.pageSize = this.defaultPageSize;
    this.searchTerm = searchTerm;
    this.getData(this.pageEvent);
  }

  getData(pageEvent: PageEvent) {
    this.bookService.list(pageEvent.pageIndex, pageEvent.pageSize, this.searchTerm).subscribe(result => {
      this.paginator.length = result.totalCount;

      this.paginator.pageIndex = result.pageIndex;

      this.paginator.pageSize = result.pageSize;

      this.books = result.data;

    }, err => console.error(err));
  }

  openDialog(book: Book): void {
    const dialogRef = this.dialog.open(DetailPopupComponent, {
      width: '550px',
      data: book
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }

  onSelectBook(book: Book) {
    this.openDialog(book);
  }
}

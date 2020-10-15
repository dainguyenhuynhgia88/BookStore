import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from '../../shared/services/base.service';
import { Pagination } from '../../shared/models/pagination';
import { Book } from '../book/book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService extends BaseService {
  private url: string = this.baseUrl + 'books';

  list(
    pageIndex: number,
    pageSize: number,
    searchTerm: string): Observable<Pagination<Book>> {

    var params = new HttpParams()
      .set('pageIndex', pageIndex.toString())
      .set('pageSize', pageSize.toString());
    if (searchTerm) {
      params = params
        .set("filterColumn", 'author,title')
        .set("searchTerm", searchTerm);
    }

    return this.httpClient.get<Pagination<Book>>(this.url, { params });
  }
}

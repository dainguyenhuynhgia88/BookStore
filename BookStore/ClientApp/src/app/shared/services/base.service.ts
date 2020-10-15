import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pagination } from '../models/pagination';

@Injectable()
export abstract class BaseService {
  constructor(protected httpClient: HttpClient, @Inject('BASE_URL') protected baseUrl: string) { }

}

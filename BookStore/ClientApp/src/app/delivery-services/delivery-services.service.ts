import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseService } from '../shared/services/base.service';
import { DeliveryService } from './delivery-services.model';


@Injectable({
  providedIn: 'root'
})
export class DeliveryPriceService extends BaseService {
  private url: string = this.baseUrl + 'deliveryServices';

  list(): Observable<Array<DeliveryService>> {
    return this.httpClient.get<Array<DeliveryService>>(this.url);
  }
}

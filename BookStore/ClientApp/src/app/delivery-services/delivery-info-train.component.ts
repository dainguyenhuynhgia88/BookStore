import { Component, Input } from '@angular/core';
import { DeliveryService } from './delivery-services.model';

@Component({
  selector: 'delivery-info-train',
  templateUrl: './delivery-info-train.component.html'
})
export class DeliveryInfoTrainComponent {
  @Input() deliveryService: DeliveryService;
}

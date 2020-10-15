import { Component, Input } from '@angular/core';
import { DeliveryService } from './delivery-services.model';

@Component({
  selector: 'delivery-info-aircraft',
  templateUrl: './delivery-info-aircraft.component.html'
})
export class DeliveryInfoAirCraftComponent {
  @Input() deliveryService: DeliveryService;
}

import { Component, Input } from '@angular/core';
import { DeliveryService } from './delivery-services.model';

@Component({
  selector: 'delivery-info-motor',
  templateUrl: './delivery-info-motor.component.html'
})
export class DeliveryInfoMotorComponent {
  @Input() deliveryService: DeliveryService;
}

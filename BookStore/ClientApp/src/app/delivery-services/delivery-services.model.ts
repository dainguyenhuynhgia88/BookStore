import { DeliveryInfo } from './delivery-info.model';

export interface DeliveryService {
  id: number;
  name: string;
  price: number;
  buttonColor: string;
  deliveryInfo: DeliveryInfo;
}

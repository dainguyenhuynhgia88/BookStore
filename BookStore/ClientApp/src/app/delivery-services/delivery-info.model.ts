export interface DeliveryInfo {
  deliveryInfoType: number;
  id: number;

  deliveryDate: Date;
  driverName: string;
  phoneNumber: string;

  dateOfArrival: Date;
  stationOfArrival: string;
  trainNo: string;

  flightNo: string;
  gateOfArrival: string;
}

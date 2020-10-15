using System;

namespace BookStore.Service.DeliveryServices.DomainModels
{
    public class AircraftDeliveryInfo : DeliveryInfo
    {
        public string FlightNo { get; set; }
        public string GateOfArrival { get; set; }
        public DateTime DateOfArrival { get; set; }
    }
}

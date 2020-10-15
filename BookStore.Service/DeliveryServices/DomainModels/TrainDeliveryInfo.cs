using System;

namespace BookStore.Service.DeliveryServices.DomainModels
{
    public class TrainDeliveryInfo : DeliveryInfo
    {
        public string TrainNo { get; set; }
        public string StationOfArrival { get; set; }
        public DateTime DateOfArrival { get; set; }
    }
}

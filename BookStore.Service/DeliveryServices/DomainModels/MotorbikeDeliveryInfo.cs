using System;

namespace BookStore.Service.DeliveryServices.DomainModels
{
    public class MotorbikeDeliveryInfo : DeliveryInfo
    {
        public string DriverName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}

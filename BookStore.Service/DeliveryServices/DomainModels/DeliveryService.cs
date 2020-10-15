using System.Collections.Generic;

namespace BookStore.Service.DeliveryServices.DomainModels
{
    public class DeliveryService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BaseCost { get; set; }
        public List<Season> Seasons { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; }
    }

    public enum DeliveryServiceEnum
    {
        Motorbike = 1,
        Train = 2,
        Aircraft = 3
    }
}

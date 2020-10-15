using BookStore.Service.DeliveryServices.DomainModels;

namespace BookStore.Service.DeliveryServices.ViewModels
{
    public class DeliveryServiceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DeliveryInfo DeliveryInfo { get; set; }
    }
}

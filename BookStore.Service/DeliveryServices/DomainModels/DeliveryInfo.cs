using BookStore.Service.DeliveryServices.Jsons;
using Newtonsoft.Json;

namespace BookStore.Service.DeliveryServices.DomainModels
{
    [JsonConverter(typeof(DeliveryInfoJsonConverter))]
    public class DeliveryInfo
    {
        public int Id { get; set; }
        public DeliveryInfoTypeEnum DeliveryInfoType { get; set; }
    }

    public enum DeliveryInfoTypeEnum
    {
        Motorbike = 1,
        Train = 2,
        Aircraft = 3
    }
}

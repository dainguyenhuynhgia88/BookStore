using BookStore.Service.DeliveryServices.DomainModels;
using Newtonsoft.Json.Linq;
using System;

namespace BookStore.Service.DeliveryServices.Jsons
{
    public class DeliveryInfoJsonConverter : JsonCreationConverter<DeliveryInfo>
    {
        protected override DeliveryInfo Create(Type objectType, JObject jObject)
        {
            if (jObject == null) throw new ArgumentNullException("jObject");

            if (jObject[nameof(MotorbikeDeliveryInfo.DriverName)] != null)
            {
                return new MotorbikeDeliveryInfo();
            }
            else if (jObject[nameof(TrainDeliveryInfo.TrainNo)] != null)
            {
                return new TrainDeliveryInfo();
            }
            else if (jObject[nameof(AircraftDeliveryInfo.FlightNo)] != null)
            {
                return new AircraftDeliveryInfo();
            }
            else
            {
                return new DeliveryInfo();
            }
        }
    }
}

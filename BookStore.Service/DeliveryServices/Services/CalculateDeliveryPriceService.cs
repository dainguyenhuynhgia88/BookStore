using BookStore.Service.DeliveryServices.DomainModels;
using BookStore.Service.DeliveryServices.ViewModels;
using Commons.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Service.DeliveryServices.Services
{
    public interface ICalculateDeliveryPriceService
    {
        IList<DeliveryServiceViewModel> Calculate(MonthEnum month, IList<DeliveryService> deliveryServices);
    }

    public class CalculateDeliveryPriceService : ICalculateDeliveryPriceService
    {
        public IList<DeliveryServiceViewModel> Calculate(MonthEnum month, IList<DeliveryService> deliveryServices)
        {
            var result = new List<DeliveryServiceViewModel>();
            if (deliveryServices.IsNullOrEmpty()) return result;

            if (deliveryServices.Any(ds => ds.Seasons.IsNullOrEmpty())) return result;

            foreach (var deliveryService in deliveryServices)
            {
                var defaultSeason = deliveryService.Seasons.SingleOrDefault(s => !s.From.HasValue && !s.To.HasValue);
                if (defaultSeason == null) continue; //invalid data

                var matchingSeason = deliveryService.Seasons.Where(s => !s.From.HasValue &&
                                                                       !s.To.HasValue &&
                                                                       s.From <= month &&
                                                                       month <= s.To)
                                                            .SingleOrDefault();

                var factor = matchingSeason != null ? matchingSeason.Factor : defaultSeason.Factor;

                var price = deliveryService.BaseCost * factor;

                result.Add(new DeliveryServiceViewModel
                {
                    Id = deliveryService.Id,
                    Name = deliveryService.Name,
                    Price = price,
                    DeliveryInfo = deliveryService.DeliveryInfo
                });
            }

            return result;
        }
    }
}

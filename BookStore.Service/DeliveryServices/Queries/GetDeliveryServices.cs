using BookStore.Service.DeliveryServices.DomainModels;
using BookStore.Service.DeliveryServices.Services;
using BookStore.Service.DeliveryServices.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Service.DeliveryServices.Queries
{
    public class GetDeliveryServices
    {
        public class Query : IRequest<IList<DeliveryServiceViewModel>>
        {

        }

        public class Handler : IRequestHandler<Query, IList<DeliveryServiceViewModel>>
        {
            private readonly ICreateDeliveryDataService _createDeliveryDataService;
            private readonly ICalculateDeliveryPriceService _calculateDeliveryPriceService;

            public Handler(ICreateDeliveryDataService createDeliveryDataService, ICalculateDeliveryPriceService calculateDeliveryPriceService)
            {
                _createDeliveryDataService = createDeliveryDataService;
                _calculateDeliveryPriceService = calculateDeliveryPriceService;
            }

            public async Task<IList<DeliveryServiceViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _createDeliveryDataService.Create();

                Enum.TryParse(DateTime.Now.Month.ToString(), out MonthEnum month);

                return await Task.FromResult(_calculateDeliveryPriceService.Calculate(month, query));
            }
        }
    }
}

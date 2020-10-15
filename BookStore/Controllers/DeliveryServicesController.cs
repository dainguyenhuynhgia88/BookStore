using BookStore.Service.DeliveryServices.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveryServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetDeliveryServices.Query { });

            return Ok(result);
        }
    }
}

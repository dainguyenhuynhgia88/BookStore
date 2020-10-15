using BookStore.Service.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int pageIndex,
            int pageSize,
            string filterColumn,
            string searchTerm)
        {
            var result = await _mediator.Send(new GetBooks.Query
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                FilterColumn = filterColumn,
                SearchTerm = searchTerm
            });

            return Ok(result);
        }
    }
}

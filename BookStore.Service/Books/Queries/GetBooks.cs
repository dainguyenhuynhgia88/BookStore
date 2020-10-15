using BookStore.Service.Books.ViewModels;
using BookStore.Service.ViewModels;
using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Service.Books.Queries
{
    public class GetBooks
    {
        public class Query : IRequest<Pagination<BookViewModel>>
        {
            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public string FilterColumn { get; set; }
            public string SearchTerm { get; set; }
        }

        public class Handler : IRequestHandler<Query, Pagination<BookViewModel>>
        {
            public async Task<Pagination<BookViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                using var streamReader = new StreamReader($"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}/Books/Data/books.json");
                string json = await streamReader.ReadToEndAsync();
                var books = JsonConvert.DeserializeObject<List<BookViewModel>>(json);
                return Pagination<BookViewModel>.Create(books, request.PageIndex, request.PageSize, request.FilterColumn, request.SearchTerm);
            }
        }
    }
}

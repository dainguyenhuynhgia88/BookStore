using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Service.Books.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public List<string> Authors { get; set; }
        public string Author => string.Join(",", Authors);
    }
}

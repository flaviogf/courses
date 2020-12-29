using System.Collections.Generic;

namespace Books.Api.Models
{
    public class BookWithCoverDto : BookDto
    {
        public IEnumerable<BookCoverDto> BookCovers { get; set; } = new List<BookCoverDto>();
    }
}

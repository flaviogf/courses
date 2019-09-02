using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BookList.Api.Models
{
    public class BookViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public int Status { get; set; }

        public IFormFile Cover { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

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
    }
}

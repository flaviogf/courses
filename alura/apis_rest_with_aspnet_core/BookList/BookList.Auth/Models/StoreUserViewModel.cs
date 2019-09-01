using System.ComponentModel.DataAnnotations;

namespace BookList.Auth.Models
{
    public class StoreUserViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BookList.Auth.Models
{
    public class SignInViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

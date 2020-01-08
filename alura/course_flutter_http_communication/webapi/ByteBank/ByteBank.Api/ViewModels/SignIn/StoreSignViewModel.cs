using System.ComponentModel.DataAnnotations;

namespace ByteBank.Api.ViewModels.SignIn
{
    public class StoreSignViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}

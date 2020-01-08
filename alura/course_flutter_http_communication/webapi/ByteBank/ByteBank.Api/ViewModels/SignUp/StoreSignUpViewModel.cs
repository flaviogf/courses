using System.ComponentModel.DataAnnotations;

namespace ByteBank.Api.ViewModels.SignUp
{
    public class StoreSignUpViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}

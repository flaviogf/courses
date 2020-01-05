using System.ComponentModel.DataAnnotations;

namespace IdentityWithDapper.Mvc.ViewModels.SignUp
{
    public class SignUpStoreViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "The {0} field must has min 8 characters.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}

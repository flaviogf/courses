using System.ComponentModel.DataAnnotations;

namespace WithoutIdentity.Mvc.ViewModels.SignIn
{
    public class SignInStoreViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} field must be max {2} and min {1} characters", MinimumLength = 8)]
        public string Password { get; set; }

        [Display(Name = "Remember")]
        public bool Remember { get; set; }
    }
}

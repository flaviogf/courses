using System.ComponentModel.DataAnnotations;

namespace TwoFactorAuthentication.Mvc.ViewModels.Profile
{
    public class ProfileEditViewModel
    {
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public string PhoneNumber { get; set; }
    }
}

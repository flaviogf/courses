using System.ComponentModel.DataAnnotations;

namespace WithoutIdentity.Mvc.ViewModels.Profile
{
    public class ProfileEditViewModel
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TwoFactorAuthentication.Mvc.ViewModels.EnableTwoFactorAuthenticator
{
    public class EnableTwoFactorAuthenticatorStoreViewModel
    {
        [Required]
        [StringLength(6, ErrorMessage ="The {0} field must be exactly {1} characters.")]
        public string Code { get; set; }
    }
}


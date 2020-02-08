using System.ComponentModel.DataAnnotations;

namespace ByteBank.Web.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
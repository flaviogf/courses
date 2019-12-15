using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Web.ViewModels.SignUp
{
    public class StoreSignUpViewModel
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [StringLength(255)]
        [Required]
        public string Email { get; set; }

        [MinLength(10)]
        [MaxLength(11)]
        [Required]
        public string Phone { get; set; }
    }
}

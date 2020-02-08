using System.ComponentModel.DataAnnotations;

namespace ByteBank.Web.ViewModels
{
    public class SignInViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
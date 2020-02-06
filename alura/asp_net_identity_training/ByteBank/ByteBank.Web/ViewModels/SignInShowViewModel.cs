using System.ComponentModel.DataAnnotations;

namespace ByteBank.Web.ViewModels
{
    public class SignInShowViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
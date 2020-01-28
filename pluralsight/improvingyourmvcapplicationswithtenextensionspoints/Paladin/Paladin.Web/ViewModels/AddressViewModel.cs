using System.ComponentModel.DataAnnotations;

namespace Paladin.Web.ViewModels
{
    public class AddressViewModel
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }
    }
}
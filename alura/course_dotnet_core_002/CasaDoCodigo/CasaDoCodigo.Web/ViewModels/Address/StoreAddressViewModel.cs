using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Web.ViewModels.Address
{
    public class StoreAddressViewModel
    {
        [MinLength(8)]
        [MaxLength(8)]
        [Required]
        public string ZipCode { get; set; }

        [StringLength(255)]
        [Required]
        public string Street { get; set; }

        [StringLength(255)]
        [Required]
        public string District { get; set; }

        [StringLength(255)]
        [Required]
        public string City { get; set; }

        [MinLength(2)]
        [MaxLength(2)]
        [Required]
        public string State { get; set; }
    }
}

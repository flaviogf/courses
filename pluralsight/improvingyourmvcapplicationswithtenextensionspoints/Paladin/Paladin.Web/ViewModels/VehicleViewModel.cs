using System.ComponentModel.DataAnnotations;

namespace Paladin.Web.ViewModels
{
    public class VehicleViewModel
    {
        [Required]
        public int Year { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public string BodyType { get; set; }

        [Required]
        [Display(Name = "Primary Use")]
        public string PrimaryUse { get; set; }

        [Required]
        [Display(Name = "Own / Lease")]
        public string OwnLease { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Paladin.Web.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public double Liability { get; set; }

        [Required]
        [Display(Name = "Road Side Assistance")]
        public bool RoadSideAssistance { get; set; }

        [Required]
        [Display(Name = "Property Damage")]
        public double PropertyDamage { get; set; }

        [Required]
        public double Collision { get; set; }

        [Required]
        public double Comprehensive { get; set; }

        [Required]
        public bool Rental { get; set; }

        [Required]
        [Display(Name = "Loan Payoff")]
        public bool LoanPayoff { get; set; }

        [Required]
        [Display(Name = "Drive Rewards")]
        public bool DriveRewards { get; set; }
    }
}
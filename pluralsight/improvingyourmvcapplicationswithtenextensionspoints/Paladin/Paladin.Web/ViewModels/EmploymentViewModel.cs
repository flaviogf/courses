using System;
using System.ComponentModel.DataAnnotations;

namespace Paladin.Web.ViewModels
{
    public class EmploymentViewModel
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string Employer { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Gross Monthly Income")]
        public double GrossMonthlyIncome { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
    }
}
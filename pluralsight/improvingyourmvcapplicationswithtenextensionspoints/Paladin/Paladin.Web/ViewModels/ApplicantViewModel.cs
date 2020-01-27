using System;
using System.ComponentModel.DataAnnotations;

namespace Paladin.Web.ViewModels
{
	public class ApplicantViewModel
	{
		[Required]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required]
		[Display(Name = "Date of Birth")]
		public DateTime DateOfBirth { get; set; }

		[Required]
		public string Phone { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		[Display(Name = "Marital Status")]
		public string MaritalStatus { get; set; }

		[Required]
		[Display(Name = "Highest Education")]
		public string HighestEducation { get; set; }

		[Required]
		[Display(Name = "License Status")]
		public string LicenseStatus { get; set; }

		[Required]
		[Display(Name = "Year Licensed")]
		public string YearLicensed { get; set; }
	}
}
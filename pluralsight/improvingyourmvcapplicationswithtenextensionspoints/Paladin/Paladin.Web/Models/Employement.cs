using System;

namespace Paladin.Web.Models
{
    public class Employement
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Employer { get; set; }

        public string Position { get; set; }

        public double GrossMonthlyIncome { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsPrimary { get; set; }

        public Applicant Applicant { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Paladin.Web.Models
{
    public class Applicant
    {
        public int Id { get; set; }

        public Guid Tracker { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string MaritalStatus { get; set; }

        public string HighestEducation { get; set; }

        public string LicenseStatus { get; set; }

        public string YearLicensed { get; set; }

        public int WorkFlowStage { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Employement> Employements { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
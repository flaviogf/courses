namespace Paladin.Web.Models
{
    public class Product
    {
        public int Id { get; set; }

        public double Liability { get; set; }

        public bool RoadSideAssistance { get; set; }

        public double PropertyDamage { get; set; }

        public double Collision { get; set; }

        public double Comprehensive { get; set; }

        public bool Rental { get; set; }

        public bool LoanPayoff { get; set; }

        public bool DriveRewards { get; set; }

        public Applicant Applicant { get; set; }
    }
}
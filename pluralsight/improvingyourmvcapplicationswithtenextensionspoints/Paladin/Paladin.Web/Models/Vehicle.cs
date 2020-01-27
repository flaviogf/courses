namespace Paladin.Web.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string BodyType { get; set; }

        public string PrimaryUse { get; set; }

        public string OwnLease { get; set; }

        public Applicant Applicant { get; set; }
    }
}
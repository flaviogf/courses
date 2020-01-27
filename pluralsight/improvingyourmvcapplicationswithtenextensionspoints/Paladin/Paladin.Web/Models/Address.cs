namespace Paladin.Web.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public bool IsMailing { get; set; }

        public Applicant Applicant { get; set; }
    }
}
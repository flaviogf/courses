namespace WebCustomers.CommandLine
{
    public class User
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Dividend { get; set; }

        public OrderHistory[] OrderHistory { get; set; }

        public ShippingPreference[] ShippingPreference { get; set; }

        public CouponsUsed[] CouponsUsed { get; set; }
    }
}
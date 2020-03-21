using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebCustomers.CommandLine
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("userId")]
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
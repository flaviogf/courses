using Flunt.Notifications;
using Store.Domain.Enums;

namespace Store.Domain.Entities
{
    public class Address : Notifiable
    {
        public Address
        (
            string street,
            string number,
            string complement,
            string district,
            string city,
            string state,
            string country,
            string zipCode,
            EAddressType type
        )
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Type = type;
        }

        public string Street { get; }
        public string Number { get; }
        public string Complement { get; }
        public string District { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string ZipCode { get; }
        public EAddressType Type { get; }
    }
}
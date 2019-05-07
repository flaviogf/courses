using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
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
            District = district;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(street, 2, nameof(Street), "Invalid street")
                .HasMinLen(number, 2, nameof(Street), "Invalid number")
                .HasMinLengthIfNotNullOrEmpty(complement, 2, nameof(Complement), "Invalid complement")
                .HasMinLen(district, 2, nameof(District), "Invalid district")
                .HasMinLen(city, 2, nameof(City), "Invalid city")
                .HasMinLen(state, 2, nameof(State), "Invalid state")
                .HasMinLen(country, 2, nameof(Country), "Invalid country")
                .HasMinLen(zipCode, 2, nameof(ZipCode), "Invalid zipCode"));
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
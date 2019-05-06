using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.ValueObjects;

namespace Store.Domain.Entities
{
    public class Customer : Notifiable
    {
        private IList<Address> _addresses;

        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Email = email;
            Document = document;
            Phone = Phone;
            _addresses = new List<Address>();

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(phone, 8, nameof(Phone), "Invalid phone"), name, document, email);
        }

        public Name Name { get; }
        public Email Email { get; }
        public Document Document { get; }
        public string Phone { get; }

        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Domain.StoreContext.Entities
{
    public class Customer : Notifiable
    {
        private readonly IList<Address> addresses;

        public Customer(Name name, Email email, Document document, string phone)
        {
            Name = name;
            Email = email;
            Document = document;
            Phone = phone;
            addresses = new List<Address>();

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(phone, 8, nameof(Phone), "Invalid phone"), name, email, document);
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => addresses.ToArray();

        public void AddAddress(Address address)
        {
            if (address.Invalid) return;
            addresses.Add(address);
        }
    }
}
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(address, nameof(Address), "Invalid email"));
        }

        public string Address { get; }
    }
}
using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(firstName, 3, nameof(FirstName), "Invalid FistName")
                .HasMinLen(lastName, 3, nameof(LastName), "Invalid LastName"));
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}
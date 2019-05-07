using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string emailAdress)
        {
            EmailAdress = emailAdress;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(emailAdress, nameof(EmailAdress), "Invalid email"));
        }

        public string EmailAdress { get; set; }
    }
}
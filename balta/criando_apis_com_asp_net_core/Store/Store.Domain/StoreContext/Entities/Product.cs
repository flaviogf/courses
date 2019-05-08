using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.StoreContext.Entities
{
    public class Product : Notifiable
    {
        public Product
        (
            string title,
            string description
        )
        {
            Title = title;
            Description = description;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(title, 2, nameof(Title), "Invalid title")
                .HasMinLen(description, 2, nameof(Description), "Invalid description"));
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
    }
}
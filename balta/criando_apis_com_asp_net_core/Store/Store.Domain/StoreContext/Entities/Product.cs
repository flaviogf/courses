using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.StoreContext.Entities
{
    public class Product : Notifiable
    {
        public Product
        (
            string title,
            string description,
            string image,
            decimal price,
            decimal quantity
        )
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            Quantity = quantity;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(title, 2, nameof(Title), "Invalid title")
                .HasMinLen(description, 2, nameof(Description), "Invalid description")
                .IsNotNullOrEmpty(image, nameof(Image), "Invalid image")
                .IsGreaterThan(price, 0, nameof(Price), "Invalid price")
                .IsGreaterOrEqualsThan(quantity, 0, nameof(Quantity), "Invalid quantity"));
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal Quantity { get; private set; }

        public void DecreaseQuantity(decimal quantity)
        {
            if (Quantity - quantity < 0)
            {
                AddNotification(nameof(Quantity), "Quantity not available");
                return;
            }
            Quantity -= quantity;
        }
    }
}
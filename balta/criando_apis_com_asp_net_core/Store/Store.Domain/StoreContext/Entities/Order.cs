using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Notifications;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private IList<OrderItem> _items;

        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public Guid Number { get; set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();

        public void Place()
        {
            Number = Guid.NewGuid();
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        public void Ship()
        {
            Status = EOrderStatus.Shipped;
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
        }

        public void AddItem(Product product, decimal quantity)
        {
            var orderItem = new OrderItem(product, quantity);

            if (orderItem.Valid)
            {
                _items.Add(orderItem);
            }

            AddNotifications(orderItem);
        }
    }
}
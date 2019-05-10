using System;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
{
    public class Order
    {
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public Guid Number { get; set; }

        public void Place()
        {
            Number = Guid.NewGuid();
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }
    }
}
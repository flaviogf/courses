using System;

namespace WiredBrain.Web.Models
{
    public class Order
    {
        public Order(Guid id, string product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            State = new Requested();
        }

        internal Order(Guid id, string product, int quantity, IState state)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            State = state;
        }

        public Guid Id { get; }

        public string Product { get; }

        public int Quantity { get; }

        public IState State { get; }

        public Order Process()
        {
            return State.Next(this);
        }
    }
}
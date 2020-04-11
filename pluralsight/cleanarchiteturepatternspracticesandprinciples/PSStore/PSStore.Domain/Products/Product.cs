using System;

namespace PSStore.Domain.Products
{
    public class Product : IEntity
    {
        internal Product()
        {
        }

        public Product(Guid id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; }

        public string Name { get; }

        public decimal Price { get; }
    }
}

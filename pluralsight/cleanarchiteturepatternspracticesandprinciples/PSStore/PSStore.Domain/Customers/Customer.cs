using System;

namespace PSStore.Domain.Customers
{
    public class Customer : IEntity
    {
        internal Customer()
        {
        }

        public Customer(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}

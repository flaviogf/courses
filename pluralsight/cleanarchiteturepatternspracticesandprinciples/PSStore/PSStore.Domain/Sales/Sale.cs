using PSStore.Domain.Customers;
using PSStore.Domain.Employees;
using PSStore.Domain.Products;
using System;

namespace PSStore.Domain.Sales
{
    public class Sale : IEntity
    {
        internal Sale()
        {
        }

        public Sale(Guid id, Customer customer, Employee employee, Product products, int quantity)
        {
            Id = id;
            Customer = customer;
            Employee = employee;
            Product = products;
            UnitPrice = products.Price;
            Quantity = quantity;
        }

        public Guid Id { get; }

        public Customer Customer { get; }

        public Employee Employee { get; }

        public Product Product { get; }

        public decimal UnitPrice { get; }

        public int Quantity { get; }

        public decimal TotalPrice { get; }
    }
}

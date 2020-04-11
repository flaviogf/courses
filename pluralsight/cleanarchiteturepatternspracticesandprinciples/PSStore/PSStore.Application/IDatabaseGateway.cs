using Microsoft.EntityFrameworkCore;
using PSStore.Domain.Customers;
using PSStore.Domain.Employees;
using PSStore.Domain.Products;
using PSStore.Domain.Sales;
using System.Threading.Tasks;

namespace PSStore.Application
{
    public interface IDatabaseGateway
    {
        DbSet<Customer> Customers { get; }

        DbSet<Employee> Employees { get; }

        DbSet<Product> Products { get; }

        DbSet<Sale> Sales { get; }

        Task Save();
    }
}

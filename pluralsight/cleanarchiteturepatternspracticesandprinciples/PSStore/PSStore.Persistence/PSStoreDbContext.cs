using Microsoft.EntityFrameworkCore;
using PSStore.Domain.Customers;
using PSStore.Domain.Employees;
using PSStore.Domain.Products;
using PSStore.Domain.Sales;

namespace PSStore.Persistence
{
    public class PSStoreDbContext : DbContext
    {
        public PSStoreDbContext(DbContextOptions<PSStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Customer

            modelBuilder
                .Entity<Customer>()
                .HasKey(it => it.Id);

            modelBuilder
                .Entity<Customer>()
                .Property(it => it.Name)
                .IsRequired();

            #endregion

            #region Employee

            modelBuilder
                .Entity<Employee>()
                .HasKey(it => it.Id);

            modelBuilder
                .Entity<Employee>()
                .Property(it => it.Name)
                .IsRequired();

            #endregion

            #region Product

            modelBuilder
                .Entity<Product>()
                .HasKey(it => it.Id);

            modelBuilder
                .Entity<Product>()
                .Property(it => it.Name)
                .IsRequired();

            modelBuilder
                .Entity<Product>()
                .Property(it => it.Price)
                .IsRequired();

            #endregion

            #region Sale

            modelBuilder
                .Entity<Sale>()
                .HasKey(it => it.Id);

            modelBuilder
                .Entity<Sale>()
                .HasOne(it => it.Customer);

            modelBuilder
                .Entity<Sale>()
                .HasOne(it => it.Employee);

            modelBuilder
                .Entity<Sale>()
                .HasOne(it => it.Product);

            modelBuilder
                .Entity<Sale>()
                .Property(it => it.UnitPrice)
                .IsRequired();

            modelBuilder
                .Entity<Sale>()
                .Property(it => it.Quantity)
                .IsRequired();

            modelBuilder
                .Entity<Sale>()
                .Property(it => it.TotalPrice)
                .IsRequired();

            #endregion
        }
    }
}

using Microsoft.EntityFrameworkCore;
using PSStore.Application;
using PSStore.Domain.Customers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PSStore.Persistence.Customers
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly PSStoreDbContext _context;

        public EFCustomerRepository(PSStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Get(Guid id)
        {
            var customer = await _context.Customers.SingleAsync(it => it.Id == id);

            return customer;
        }

        public IQueryable<Customer> GetAll()
        {
            return _context.Customers;
        }
    }
}

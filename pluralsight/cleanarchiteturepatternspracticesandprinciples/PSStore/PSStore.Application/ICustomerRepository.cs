using PSStore.Domain.Customers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PSStore.Application
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAll();

        Task<Customer> Get(Guid id);
    }
}

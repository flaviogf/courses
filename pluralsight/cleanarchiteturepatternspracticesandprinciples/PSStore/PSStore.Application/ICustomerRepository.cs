using PSStore.Domain.Customers;
using System;
using System.Threading.Tasks;

namespace PSStore.Application
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(Guid id);
    }
}

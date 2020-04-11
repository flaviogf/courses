using PSStore.Domain.Employees;
using System;
using System.Threading.Tasks;

namespace PSStore.Application
{
    public interface IEmployeeRepository
    {
        Task<Employee> Get(Guid id);
    }
}

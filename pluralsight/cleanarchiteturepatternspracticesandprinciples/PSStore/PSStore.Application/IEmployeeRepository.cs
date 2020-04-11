using PSStore.Domain.Employees;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PSStore.Application
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAll();

        Task<Employee> Get(Guid id);
    }
}

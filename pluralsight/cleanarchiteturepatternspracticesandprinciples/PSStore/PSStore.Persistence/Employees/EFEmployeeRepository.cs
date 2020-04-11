using Microsoft.EntityFrameworkCore;
using PSStore.Application;
using PSStore.Domain.Employees;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PSStore.Persistence.Employees
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private readonly PSStoreDbContext _context;

        public EFEmployeeRepository(PSStoreDbContext context)
        {
            _context = context;
        }

        public Task<Employee> Get(Guid id)
        {
            var employee = _context.Employees.FirstAsync(it => it.Id == id);

            return employee;
        }

        public IQueryable<Employee> GetAll()
        {
            return _context.Employees;
        }
    }
}

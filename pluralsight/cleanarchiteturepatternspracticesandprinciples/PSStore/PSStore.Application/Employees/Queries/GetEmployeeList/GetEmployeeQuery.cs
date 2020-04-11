using System.Collections.Generic;
using System.Linq;

namespace PSStore.Application.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeQuery : IGetEmployeeQuery
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeQuery(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IList<GetEmployeeListModel> Execute()
        {
            var employees = from e in _employeeRepository.GetAll()
                            orderby e.Name
                            select new GetEmployeeListModel
                            {
                                Id = e.Id,
                                Name = e.Name
                            };

            return employees.ToList();
        }
    }
}

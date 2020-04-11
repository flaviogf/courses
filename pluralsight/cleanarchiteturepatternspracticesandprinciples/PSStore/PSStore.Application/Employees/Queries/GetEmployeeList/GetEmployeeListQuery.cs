using System.Collections.Generic;
using System.Linq;

namespace PSStore.Application.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQuery : IGetEmployeeListQuery
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeListQuery(IEmployeeRepository employeeRepository)
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

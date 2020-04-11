using Microsoft.AspNetCore.Mvc;
using PSStore.Application.Employees.Queries.GetEmployeeList;

namespace PSStore.Presentation.Controllers
{
    [Route("[controller]")]
    public class EmployeeController:Controller
    {
        private readonly IGetEmployeeListQuery _getEmployeeListQuery;

        public EmployeeController(IGetEmployeeListQuery getEmployeeListQuery)
        {
            _getEmployeeListQuery = getEmployeeListQuery;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var employees = _getEmployeeListQuery.Execute();

            return View(employees);
        }
    }
}

using System.Collections.Generic;

namespace PSStore.Application.Employees.Queries.GetEmployeeList
{
    public interface IGetEmployeeQuery
    {
        IList<GetEmployeeListModel> Execute();
    }
}

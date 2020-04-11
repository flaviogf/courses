using System.Collections.Generic;

namespace PSStore.Application.Employees.Queries.GetEmployeeList
{
    public interface IGetEmployeeListQuery
    {
        IList<GetEmployeeListModel> Execute();
    }
}

using System.Collections.Generic;

namespace PSStore.Application.Customers.Queries.GetCustomerList
{
    public interface IGetCustomerListQuery
    {
        IList<GetCustomerListModel> Execute();
    }
}

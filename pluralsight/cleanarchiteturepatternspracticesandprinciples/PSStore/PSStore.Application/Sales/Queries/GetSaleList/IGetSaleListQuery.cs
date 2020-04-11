using System.Collections.Generic;

namespace PSStore.Application.Sales.Queries.GetSaleList
{
    public interface IGetSaleListQuery
    {
        IList<GetSaleListModel> Execute();
    }
}

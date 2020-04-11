using System.Collections.Generic;

namespace PSStore.Application.Products.Queries.GetProductList
{
    public interface IGetProductListQuery
    {
        IList<GetProductListModel> Execute();
    }
}

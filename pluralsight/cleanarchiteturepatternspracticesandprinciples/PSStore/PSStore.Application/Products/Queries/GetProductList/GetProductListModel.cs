using System;

namespace PSStore.Application.Products.Queries.GetProductList
{
    public class GetProductListModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}

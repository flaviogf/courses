using System.Collections.Generic;
using System.Linq;

namespace PSStore.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IGetProductListQuery
    {
        private readonly IProductRepository _productRepository;

        public GetProductListQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<GetProductListModel> Execute()
        {
            var products = from p in _productRepository.GetAll()
                           select new GetProductListModel
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Price = p.Price
                           };

            return products.ToList();
        }
    }
}

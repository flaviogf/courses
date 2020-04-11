using System.Collections.Generic;
using System.Linq;

namespace PSStore.Application.Sales.Queries.GetSaleList
{
    public class GetSaleListQuery : IGetSaleListQuery
    {
        private readonly ISaleRepository _saleRepository;

        public GetSaleListQuery(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public IList<GetSaleListModel> Execute()
        {
            var sales = from s in _saleRepository.GetAll()
                        select new GetSaleListModel
                        {
                            Id = s.Id,
                            CustomerName = s.Customer.Name,
                            EmployeeName = s.Employee.Name,
                            ProductName = s.Product.Name,
                            UnitPrice = s.UnitPrice,
                            Quantity = s.Quantity,
                            TotalPrice = s.TotalPrice
                        };

            return sales.ToList();
        }
    }
}

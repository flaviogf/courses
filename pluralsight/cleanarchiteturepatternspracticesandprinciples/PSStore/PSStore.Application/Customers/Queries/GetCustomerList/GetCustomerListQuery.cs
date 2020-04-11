using System.Collections.Generic;
using System.Linq;

namespace PSStore.Application.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQuery : IGetCustomerListQuery
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerListQuery(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IList<GetCustomerListModel> Execute()
        {
            var customers = from c in _customerRepository.GetAll()
                            orderby c.Name ascending
                            select new GetCustomerListModel
                            {
                                Id = c.Id,
                                Name = c.Name
                            };

            return customers.ToList();
        }
    }
}

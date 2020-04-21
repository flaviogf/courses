using HandlingFailures.Core;

namespace HandlingFailures.UI
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        public Maybe<Customer> Get(int id)
        {
            return new Customer("123", 1500);
        }
    }
}

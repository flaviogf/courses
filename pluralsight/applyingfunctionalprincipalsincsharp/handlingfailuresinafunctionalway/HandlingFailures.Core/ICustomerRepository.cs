namespace HandlingFailures.Core
{
    public interface ICustomerRepository
    {
        Maybe<Customer> Get(int id);
    }
}

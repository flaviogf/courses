namespace FunctionalPrinciples.AvoidingNulls.Core
{
    public interface ICustomerRepository
    {
        Result Add(Customer customer);

        Maybe<Customer> FindOneByEmail(string email);
    }
}
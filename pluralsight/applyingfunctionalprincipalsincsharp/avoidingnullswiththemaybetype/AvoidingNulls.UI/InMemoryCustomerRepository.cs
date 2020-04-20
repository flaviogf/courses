using System;
using FunctionalPrinciples.AvoidingNulls.Core;

namespace FunctionalPrinciples.AvoidingNulls.UI
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        public Result Add(Customer customer)
        {
            Console.WriteLine("AvoidingNulls: adding {0}", customer.Name);
            
            return Result.Ok();
        }

        public Maybe<Customer> FindOneByEmail(string email)
        {
            return null;
        }
    }
}
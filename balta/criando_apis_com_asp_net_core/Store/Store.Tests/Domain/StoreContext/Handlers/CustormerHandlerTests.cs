using System.Threading;
using Store.Domain.StoreContext.Commands;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Xunit;

namespace Store.Tests.Domain.StoreContext.Handlers
{
    public class MockCustomerRepository : ICustomerRepository
    {
        public bool CheckEmail(string email)
        {
            return false;
        }
    }

    public class CustomerHandlerTests
    {
        [Fact]
        public async void ShouldValidFalseWhenEmailIsNotAvailable()
        {
            var customerRepository = new MockCustomerRepository();

            var customerHandler = new CustomerHandler(customerRepository);

            var createCustomerCommand = new CreateCustomerCommand("Steve", "Rogers", "61946855065", "captain@marvel.com", "016999999999");

            await customerHandler.Handle(createCustomerCommand, CancellationToken.None);

            Assert.False(customerHandler.Valid);
        }
    }
}
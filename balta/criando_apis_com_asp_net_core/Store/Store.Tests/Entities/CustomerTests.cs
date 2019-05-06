using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Xunit;

namespace Store.Tests.Entities
{
    public class CustomerTests
    {
        private Customer _steve;

        public CustomerTests()
        {
            var name = new Name("Steve", "Rogers");
            var document = new Document("434.153.770-91");
            var email = new Email("captain@marvel.com");
            _steve = new Customer(name, document, email, "016999999999");
        }

        [Fact]
        public void ShouldReturnValidTrueWhenAllInformationIsValid()
        {
            Assert.True(_steve.Valid);
        }

        [Fact]
        public void ShouldContainsAAddressWhenAddAddress()
        {
            var address = new Address(
                "Street X",
                "100",
                "",
                "Brooklin",
                "New York",
                "New York",
                "USA",
                "10044",
                EAddressType.Shipping
            );

            _steve.AddAddress(address);

            Assert.Equal(1, _steve.Addresses.Count);
        }
    }
}
using Store.Domain.StoreContext.ValueObjects;
using Store.Domain.StoreContext.Entities;
using Xunit;
using Store.Domain.StoreContext.Enums;

namespace Store.Tests.Domain.StoreContext.Entities
{
    public class CustomerTests
    {
        private Customer _steve;

        public CustomerTests()
        {
            var name = new Name("Steve", "Rogers");
            var email = new Email("captain@marvel.com");
            var document = new Document("543.917.900-33");
            var phone = "016999999999";
            _steve = new Customer(name, email, document, phone);
        }

        [Fact]
        public void ShouldValidTrueWhenAllInformationIsValid()
        {
            Assert.True(_steve.Valid);
        }

        [Fact]
        public void ShouldAddressListIsEmptyWhenCustormerIsCreated()
        {
            Assert.Equal(0, _steve.Addresses.Count);
        }

        [Fact]
        public void ShoudlInvalidTrueWhenNameIsInvalid()
        {
            var name = new Name("", "Rogers");
            var email = new Email("captain@marvel.com");
            var document = new Document("543.917.900-33");
            var phone = "016999999999";
            var customer = new Customer(name, email, document, phone);

            Assert.True(customer.Invalid);
        }

        [Fact]
        public void ShouldInvalidTrueWhenEmailIsInvalid()
        {
            var name = new Name("Steve", "Rogers");
            var email = new Email("");
            var document = new Document("543.917.900-33");
            var phone = "016999999999";
            var customer = new Customer(name, email, document, phone);

            Assert.True(customer.Invalid);
        }

        [Fact]
        public void ShouldInvalidTrueWhenDocumentIsInvalid()
        {
            var name = new Name("Steve", "Rogers");
            var email = new Email("captain@marvel.com");
            var document = new Document("");
            var phone = "016999999999";
            var customer = new Customer(name, email, document, phone);

            Assert.True(customer.Invalid);
        }

        [Fact]
        public void ShouldInvalidTrueWhenPhoneIsInvalid()
        {
            var name = new Name("Steve", "Rogers");
            var email = new Email("captain@marvel.com");
            var document = new Document("543.917.900-33");
            var phone = "";
            var customer = new Customer(name, email, document, phone);

            Assert.True(customer.Invalid);
        }

        [Fact]
        public void ShouldContainsAAddressWhenAddAddressIsCalledWithValidAddress()
        {
            var address = new Address(
                "Street Y",
                "100",
                "",
                "Brooklin",
                "New York",
                "New York",
                "USA",
                "10400",
                EAddressType.Shipping);

            _steve.AddAddress(address);

            Assert.Equal(1, _steve.Addresses.Count);
        }

        [Fact]
        public void ShouldContainsDoNotContainsAddressWhenAddAddressIsCalledWithInvalidAddress()
        {
            var address = new Address(
                "Street Y",
                "",
                "",
                "Brooklin",
                "New York",
                "New York",
                "USA",
                "10400",
                EAddressType.Shipping);

            _steve.AddAddress(address);

            Assert.Equal(0, _steve.Addresses.Count);
        }
    }
}
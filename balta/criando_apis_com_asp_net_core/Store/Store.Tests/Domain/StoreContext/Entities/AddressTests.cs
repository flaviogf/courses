using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Xunit;

namespace Store.Tests.Domain.StoreContext.Entities
{
    public class AddressTests
    {
        [Fact]
        public void ShouldReturnValidTrueWhenAllInformationIsValid()
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

            Assert.True(address.Valid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenStreetIsInvalid()
        {
            var address = new Address(
                "A",
                "100",
                "",
                "Brooklin",
                "New York",
                "New York",
                "USA",
                "10400",
                EAddressType.Shipping);

            Assert.True(address.Invalid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenNumberIsInvalid()
        {
            var address = new Address(
                "Street Y",
                "B",
                "",
                "Brooklin",
                "New York",
                "New York",
                "USA",
                "10400",
                EAddressType.Shipping);

            Assert.True(address.Invalid);
        }

        [Fact]
        public void ShoudlReturnInvalidTrueWhenComplementIsInvalid()
        {
            var address = new Address(
                "Street Y",
                "100",
                "C",
                "Brooklin",
                "New York",
                "New York",
                "USA",
                "10400",
                EAddressType.Shipping);

            Assert.True(address.Invalid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenDistrictIsInvalid()
        {
            var address = new Address(
                "Street Y",
                "100",
                "",
                "D",
                "New York",
                "New York",
                "USA",
                "10400",
                EAddressType.Shipping);

            Assert.True(address.Invalid);
        }
        [Fact]
        public void ShouldReturnInvalidTrueWhenCiytIsInvalid()
        {
            var address = new Address(
                "Street Y",
                "100",
                "",
                "Brooklin",
                "E",
                "New York",
                "USA",
                "10400",
                EAddressType.Shipping);

            Assert.True(address.Invalid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenStateIsInvalid()
        {
            var address = new Address(
                "Street Y",
                "100",
                "",
                "Brooklin",
                "New York",
                "F",
                "USA",
                "10400",
                EAddressType.Shipping);

            Assert.True(address.Invalid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenCountryIsInvalid()
        {
            var address = new Address(
                "Street Y",
                "100",
                "",
                "Brooklin",
                "New York",
                "New York",
                "G",
                "10400",
                EAddressType.Shipping);

            Assert.True(address.Invalid);
        }

        [Fact]
        public void ShouldReturnInvalidTrueWhenZipoCodeIsInvalid()
        {
            var address = new Address(
                "Street Y",
                "100",
                "",
                "Brooklin",
                "New York",
                "New York",
                "USA",
                "H",
                EAddressType.Shipping);

            Assert.True(address.Invalid);
        }
    }
}
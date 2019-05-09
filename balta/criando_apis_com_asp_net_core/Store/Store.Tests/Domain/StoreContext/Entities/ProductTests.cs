using Store.Domain.StoreContext.Entities;
using Xunit;

namespace Store.Tests.Domain.StoreContext.Entities
{
    public class ProductTests
    {
        private Product _xbox;

        public ProductTests()
        {
            _xbox = new Product(
                "Xbox One",
                "Microsof Xbox One",
                "xbox.jpg",
                100.99M,
                10M
            );
        }

        [Fact]
        public void ShouldValidTrueWhenAllInformationIsValid()
        {
            Assert.True(_xbox.Valid);
        }

        [Fact]
        public void ShouldInvalidTrueWhenTitleDoNotContainsMinLenTwo()
        {
            var xbox = new Product(
                "",
                "Microsof Xbox One",
                "xbox.jpg",
                100.99M,
                0M
            );

            Assert.True(xbox.Invalid);
        }

        [Fact]
        public void ShouldInvalidTrueWhenDescriptionDoNotContainsMinLenTwo()
        {
            var xbox = new Product(
                "Xbox One",
                "",
                "xbox.jpg",
                100.99M,
                0M
            );

            Assert.True(xbox.Invalid);
        }

        [Fact]
        public void ShouldInvalidTrueWhenImageIsEmpty()
        {
            var xbox = new Product(
                "Xbox One",
                "Microsof Xbox One",
                "",
                100.99M,
                0M
            );

            Assert.True(xbox.Invalid);
        }

        [Fact]
        public void ShouldInvalidTrueWhenPriceIsLowerOrEqualsThanZero()
        {
            var xbox = new Product(
                "Xbox One",
                "Microsof Xbox One",
                "xbox.jpg",
                0M,
                0M
            );

            Assert.True(xbox.Invalid);
        }

        [Fact]
        public void ShouldInvalidTrueWhenQuantityIsLowerThanZero()
        {
            var xbox = new Product(
                "Xbox One",
                "Microsof Xbox One",
                "xbox.jpg",
                100.99M,
                -1M
            );

            Assert.True(xbox.Invalid);
        }

        [Fact]
        public void ShouldDecreaseQuantityWhenQuantityIsAvailable()
        {
            _xbox.DecreaseQuantity(5M);

            Assert.Equal(5M, _xbox.Quantity);
        }

        [Fact]
        public void ShouldDoNotDecreaseQuantityWhenDecreaseQuantityIsCalledWithQuantityGreaterThanQuantityAvailable()
        {
            _xbox.DecreaseQuantity(20M);

            Assert.Equal(10M, _xbox.Quantity);
        }

        [Fact]
        public void ShouldHasNotificiationWhenDecreaseQuantityIsCalledWithQuantityGreaterThanQuantityAvailable()
        {
            _xbox.DecreaseQuantity(20M);

            Assert.Equal(1, _xbox.Notifications.Count);
        }
    }
}
using Store.Domain.StoreContext.Entities;
using Xunit;

namespace Store.Tests.Domain.StoreContext.Entities
{
    public class ProductTests
    {
        [Fact]
        public void ShouldValidTrueWhenAllInformationIsValid()
        {
            var xbox = new Product(
                "Xbox One",
                "Microsof Xbox One"
            );

            Assert.True(xbox.Valid);
        }

        public void ShouldInvalidTrueWhenTitleDoNotContainsMinLenTwo()
        {

        }

        public void ShouldInvalidTrueWhenDescriptionDoNotContainsMinLenTwo()
        {

        }

        public void ShouldInvalidTrueWhenImageIsEmpty()
        {

        }

        public void ShouldInvalidTrueWhenPriceIsLowerOrEqualsThanZero()
        {

        }

        public void ShouldInvalidTrueWhenQuantityIsLowerThanZero()
        {

        }
    }
}
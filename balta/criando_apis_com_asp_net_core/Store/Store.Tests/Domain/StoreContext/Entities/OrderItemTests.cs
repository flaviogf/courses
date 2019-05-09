using Store.Domain.StoreContext.Entities;
using Xunit;

namespace Store.Tests.Domain.StoreContext.Entities
{
    public class OrderItemTests
    {
        private Product _xbox;
        private OrderItem _xboxOrderItem;

        public OrderItemTests()
        {
            _xbox = new Product(
                "Xbox One",
                "Microsof Xbox One",
                "xbox.jpg",
                100.99M,
                10M
            );

            _xboxOrderItem = new OrderItem(
                _xbox,
                5M
            );
        }

        [Fact]
        public void ShouldValidTrueWhanAllInformationIsValid()
        {
            Assert.True(_xboxOrderItem.Valid);
        }

        [Fact]
        public void ShouldPriceOfOrderItemIsEqualToPriceOfProduct()
        {
            Assert.Equal(_xboxOrderItem.Price, _xbox.Price);
        }


        [Fact]
        public void ShouldInvalidTrueWhenQuantityIsGreaterThanQuantityProductAvailable()
        {
            var xboxOrderItem = new OrderItem(_xbox, 20M);

            Assert.True(xboxOrderItem.Invalid);
        }
    }
}
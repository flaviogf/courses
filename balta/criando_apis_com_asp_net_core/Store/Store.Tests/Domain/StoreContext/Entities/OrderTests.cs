using System;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Store.Domain.StoreContext.ValueObjects;
using Xunit;

namespace Store.Tests.Domain.StoreContext.Entities
{
    public class OrderTests
    {
        private Customer _steve;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("Steve", "Rogers");
            var email = new Email("captain@marvel.com");
            var document = new Document("543.917.900-33");
            var phone = "016999999999";
            _steve = new Customer(name, email, document, phone);
            _order = new Order(_steve);
        }

        [Fact]
        public void ShouldCreateDataEqualToTodayWhenCreateOrder()
        {
            Assert.Equal(DateTime.Today.Date, _order.CreateDate.Date);
        }

        [Fact]
        public void ShouldStatusEqualToCreatedWhenCreateOrder()
        {
            Assert.Equal(EOrderStatus.Created, _order.Status);
        }

        [Fact]
        public void ShouldGenerateOrderNumberWhenOrderIsPlace()
        {
            _order.Place();

            Assert.NotEqual(Guid.Empty, _order.Number);
        }

        [Fact]
        public void ShouldStatusEqualToPaidWhenOrderIsPay()
        {
            _order.Pay();

            Assert.Equal(EOrderStatus.Paid, _order.Status);
        }

        [Fact]
        public void ShouldStatusEqualToShippedWhenOrderIsShip()
        {
            _order.Ship();

            Assert.Equal(EOrderStatus.Shipped, _order.Status);
        }

        [Fact]
        public void ShouldStatusEqualToCanceledWhenOrderIsCancel()
        {
            _order.Cancel();

            Assert.Equal(EOrderStatus.Canceled, _order.Status);
        }

        [Fact]
        public void ShouldAddItemWhenProductContainsQuantity()
        {
            var nintendo = new Product("Nintendo Switch", "Nintendo Switch", "switch.jpg", 1000.00M, 10M);

            _order.AddItem(nintendo, 3M);

            Assert.Equal(1, _order.Items.Count);
        }

        [Fact]
        public void ShouldDoNotAddItemWhenProductDoNotContainsQuantity()
        {
            var nintendo = new Product("Nintendo Switch", "Nintendo Switch", "switch.jpg", 1000.00M, 1M);

            _order.AddItem(nintendo, 3M);

            Assert.Equal(0, _order.Items.Count);
        }

        [Fact]
        public void ShouldValidFalseWhenAddItemWithoutQuantity()
        {
            var nintendo = new Product("Nintendo Switch", "Nintendo Switch", "switch.jpg", 1000.00M, 1M);

            _order.AddItem(nintendo, 3M);

            Assert.False(_order.Valid);
        }
    }
}
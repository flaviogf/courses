using System;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Xunit;

namespace Store.Tests.Domain.StoreContext.Entities
{
    public class DeliveryTests
    {
        private Delivery _xboxDelivery;

        public DeliveryTests()
        {
            var estimatedDeleviryDate = DateTime.Now + TimeSpan.FromDays(2);

            _xboxDelivery = new Delivery(estimatedDeleviryDate);
        }

        [Fact]
        public void ShouldValidWhenEstimatedDeliveryDateIsGreatherOrEqualsThanDateToday()
        {
            Assert.True(_xboxDelivery.Valid);
        }

        [Fact]
        public void ShouldInvalidWhenEstimatedDeliveruDateIsLowerThanDateToday()
        {
            var estimatedDeleviryDate = DateTime.Now - TimeSpan.FromDays(2);

            var xboxDelivery = new Delivery(estimatedDeleviryDate);

            Assert.True(xboxDelivery.Invalid);
        }

        [Fact]
        public void ShouldStatusIsEqualToWaitingWhenDeliveryIsCreated()
        {
            Assert.Equal(EDeliveryStatus.Waiting, _xboxDelivery.Status);
        }

        [Fact]
        public void ShouldStatusIsEqualToShippedWhenShipIsCalledWithEstimatedDataDeliveryGreaterOrEqualThanDateToday()
        {
            _xboxDelivery.Ship();

            Assert.Equal(EDeliveryStatus.Shipped, _xboxDelivery.Status);
        }

        [Fact]
        public void ShouldStatusIsEqualToCanceledWhenShipIsCalledWithEstimatedDateDeliveryLowerThanDateToday()
        {
            var estimatedDeleviryDate = DateTime.Now - TimeSpan.FromDays(2);

            var xboxDelivery = new Delivery(estimatedDeleviryDate);

            xboxDelivery.Ship();

            Assert.Equal(EDeliveryStatus.Canceled, xboxDelivery.Status);
        }

        [Fact]
        public void ShouldStatusIsEqualToCanceldWhenCancelIsCalledWithDeliveryDoNotShipped()
        {
            _xboxDelivery.Cancel();

            Assert.Equal(EDeliveryStatus.Canceled, _xboxDelivery.Status);
        }

        [Fact]
        public void ShouldStatusIsEqualToShippedWhenCancelIsCalledWithDeliveryShipped()
        {
            _xboxDelivery.Ship();

            _xboxDelivery.Cancel();

            Assert.Equal(EDeliveryStatus.Shipped, _xboxDelivery.Status);
        }
    }
}
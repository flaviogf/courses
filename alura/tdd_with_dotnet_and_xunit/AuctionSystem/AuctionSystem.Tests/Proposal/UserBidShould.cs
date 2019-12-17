using AuctionSystem.Core.Proposal;
using System;
using Xunit;

namespace AuctionSystem.Tests.Proposal
{
    public class UserBidShould
    {
        [Fact]
        public async void ReturnABid()
        {
            var user = new User(Guid.NewGuid());

            var bid = await user.Bid(0);

            Assert.IsAssignableFrom<Bid>(bid);
        }

        [Fact]
        public async void ReturnABidAssignedByUser()
        {
            var user = new User(Guid.NewGuid());

            var bid = await user.Bid(0);

            Assert.Equal(user, bid.User);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(5000)]
        [InlineData(10000)]
        public async void ReturnABidWithThePassedValue(int value)
        {
            var user = new User(Guid.NewGuid());

            var bid = await user.Bid(value);

            Assert.Equal(value, bid.Value);
        }
    }
}

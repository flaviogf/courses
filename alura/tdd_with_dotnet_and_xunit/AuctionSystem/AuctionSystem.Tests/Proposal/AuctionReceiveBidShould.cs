using AuctionSystem.Core.Proposal;
using System;
using Xunit;

namespace AuctionSystem.Tests.Proposal
{
    public class AuctionReceiveBidShould
    {
        [Fact]
        public async void HaveOneBidWhenItReceivesOneBid()
        {
            var xbox = new Auction(Guid.NewGuid());

            var flavio = new User(Guid.NewGuid());

            var bid = await flavio.Bid(1000);

            await xbox.Receive(bid);

            Assert.Collection(xbox.Bids,
            (it) =>
            {
                Assert.Equal(bid, it);
            });
        }
    }
}

using AuctionSystem.Core.Proposal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AuctionSystem.Tests.Proposal
{
    public class AuctionReceiveBidShould
    {
        [Theory]
        [ClassData(typeof(BidTestData))]
        public async void HaveTheNumberOfBidReceived(int numberOfBids, Bid[] bids)
        {
            var xbox = new Auction();

            var tasks = from bid in bids select xbox.Receive(bid);

            Task.WaitAll(tasks.ToArray());

            Assert.Equal(numberOfBids, xbox.Bids.Count);
        }
    }

    public class BidTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, new Bid[] { new Bid(new User(Guid.NewGuid()), 1000) } };
            yield return new object[] { 2, new Bid[] { new Bid(new User(Guid.NewGuid()), 5000), new Bid(new User(Guid.NewGuid()), 5000) } };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

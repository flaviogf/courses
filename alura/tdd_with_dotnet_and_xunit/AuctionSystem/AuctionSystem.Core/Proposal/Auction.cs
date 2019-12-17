using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Proposal
{
    public class Auction : Entity
    {
        private List<Bid> _bids;

        public Auction(Guid Id) : base(Id)
        {
            _bids = new List<Bid>();
        }

        public IReadOnlyList<Bid> Bids => _bids;

        public async Task Receive(Bid bid)
        {
            _bids.Add(bid);
        }
    }
}

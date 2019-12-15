using System;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Proposal
{
    public class User
    {
        public User(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public async Task<Bid> Bid(int value)
        {
            return new Bid(this, value);
        }
    }
}

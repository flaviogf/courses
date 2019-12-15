
using System;
using System.Threading.Tasks;

namespace AuctionSystem.Core.Proposal
{
    public class User : Entity
    {
        public User(Guid id) : base(id)
        {
        }

        public async Task<Bid> Bid(int value)
        {
            return new Bid(Guid.NewGuid(), this, value);
        }
    }
}

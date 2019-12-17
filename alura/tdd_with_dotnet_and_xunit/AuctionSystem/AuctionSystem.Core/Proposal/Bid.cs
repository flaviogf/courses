using System;

namespace AuctionSystem.Core.Proposal
{
    public class Bid : Entity
    {
        public Bid(Guid Id, User user, int value) : base(Id)
        {
            User = user;
            Value = value;
        }

        public User User { get; }

        public int Value { get; }
    }
}

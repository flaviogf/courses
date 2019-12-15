namespace AuctionSystem.Core.Proposal
{
    public class Bid
    {
        public Bid(User user, int value)
        {
            User = user;
            Value = value;
        }

        public User User { get; }

        public int Value { get; }
    }
}

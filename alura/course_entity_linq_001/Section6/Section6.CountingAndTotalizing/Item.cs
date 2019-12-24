using System;

namespace Section6.CountingAndTotalizing
{
    public class Item
    {
        public int Id { get; set; }

        public int TrackId { get; set; }

        public Track Track { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Item item && Id == item.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

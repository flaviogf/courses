using System;

namespace Section6.CountingAndTotalizing
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Artist artist && Id == artist.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

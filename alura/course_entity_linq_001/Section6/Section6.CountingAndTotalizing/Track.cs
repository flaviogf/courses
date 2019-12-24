using System;

namespace Section6.CountingAndTotalizing
{
    public class Track
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public int Price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Track track && Id == track.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

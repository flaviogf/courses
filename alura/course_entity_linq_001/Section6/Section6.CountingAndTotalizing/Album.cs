using System;

namespace Section6.CountingAndTotalizing
{
    public class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Album album && Id == album.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}

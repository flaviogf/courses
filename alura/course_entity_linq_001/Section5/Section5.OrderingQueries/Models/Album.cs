using System.Collections.Generic;

namespace Section5.OrderingQueries.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}

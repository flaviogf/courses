using System.Collections.Generic;

namespace Section5.OrderingQueries.Models
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}

namespace Section6.CountingAndTotalizing
{
    public class Track
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AlbumId { get; set; }

        public Album Album { get; set; }

        public int Price { get; set; }
    }
}

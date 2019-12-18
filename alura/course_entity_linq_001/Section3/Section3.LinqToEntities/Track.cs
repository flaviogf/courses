namespace Section3.LinqToEntities
{
    public class Track
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}

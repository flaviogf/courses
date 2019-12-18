namespace Section4.AssociatingAndFilteringTheModelEntities
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}

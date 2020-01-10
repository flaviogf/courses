namespace Section6.StudyAnalysisAndPlayWithQueriesThroughLinqPad
{
    public class Track
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}

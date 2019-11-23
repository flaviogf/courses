namespace Section9.UsingTrace
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString() => $"Movie=[Id={Id}, Name={Name}]";
    }
}

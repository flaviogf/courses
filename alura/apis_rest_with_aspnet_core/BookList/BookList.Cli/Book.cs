namespace BookList.Cli
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Summary { get; set; }

        public override string ToString() => $"Book[Id={Id}, Name={Name}]";
    }
}

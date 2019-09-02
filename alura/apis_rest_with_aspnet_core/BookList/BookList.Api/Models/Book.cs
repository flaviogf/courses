namespace BookList.Api.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Summary { get; set; }

        public EBookStatus Status { get; set; }
    }
}

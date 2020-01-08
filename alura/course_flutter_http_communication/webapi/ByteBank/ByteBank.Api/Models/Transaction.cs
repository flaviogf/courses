namespace ByteBank.Api.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public Contact Contact { get; set; }
    }
}

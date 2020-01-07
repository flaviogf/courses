namespace Section1.LearnToCreateReportsWithPagination
{
    public class Invoice
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
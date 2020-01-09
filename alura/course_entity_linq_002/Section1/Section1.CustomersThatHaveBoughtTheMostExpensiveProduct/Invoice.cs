namespace Section1.CustomersThatHaveBoughtTheMostExpensiveProduct
{
    public class Invoice
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}

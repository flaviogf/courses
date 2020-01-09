using System.Collections.Generic;

namespace Section1.CustomersThatHaveBoughtTheMostExpensiveProduct
{
    public class Track
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}

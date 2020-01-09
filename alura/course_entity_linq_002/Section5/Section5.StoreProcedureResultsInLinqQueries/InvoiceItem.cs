namespace Section5.StoreProcedureResultsInLinqQueries
{
    public class InvoiceItem
    {
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public int TrackId { get; set; }

        public Track Track { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}

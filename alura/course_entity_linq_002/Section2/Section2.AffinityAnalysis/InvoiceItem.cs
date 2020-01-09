namespace Section2.AffinityAnalysis
{
    public class InvoiceItem
    {
        public int InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public int TrackId { get; set; }

        public Track Track { get; set; }
    }
}

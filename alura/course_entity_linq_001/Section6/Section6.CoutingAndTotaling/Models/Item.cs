namespace Section6.CoutingAndTotaling.Models
{
    public class Item
    {
        public int Id { get; set; }

        public int TrackId { get; set; }

        public Track Track { get; set; }

        public int Quantity { get; set; }
    }
}
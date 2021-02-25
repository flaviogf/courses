using System;

namespace GloboTicket.Services.ShoppingBasket.Models
{
    public class EventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;

namespace GloboTicket.Services.ShoppingBasket.Models
{
    public class BasketLineDto
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Guid EventId { get; set; }
        public EventDto Event { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
    }
}

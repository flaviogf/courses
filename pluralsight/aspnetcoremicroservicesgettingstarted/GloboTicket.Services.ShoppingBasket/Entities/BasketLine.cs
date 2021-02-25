using System;

namespace GloboTicket.Services.ShoppingBasket.Entities
{
    public class BasketLine
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public int TicketAmount { get; set; }
        public int Price { get; set; }
    }
}

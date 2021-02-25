using System;

namespace GloboTicket.Services.ShoppingBasket.Models
{
    public class BasketLineForCreationDto
    {
        public Guid EventId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
    }
}

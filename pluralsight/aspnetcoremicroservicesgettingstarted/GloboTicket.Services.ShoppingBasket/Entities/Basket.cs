using System;
using System.Collections.Generic;

namespace GloboTicket.Services.ShoppingBasket.Entities
{
    public class Basket
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public IList<BasketLine> BasketLines { get; set; } = new List<BasketLine>();
    }
}

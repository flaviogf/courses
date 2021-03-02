using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.Services.ShoppingBasket.Entities;

namespace GloboTicket.Services.ShoppingBasket.Repositories
{
    public interface IBasketRepository
    {
        Task Add(Basket basket);
        Task AddBasketLine(Guid basketId, BasketLine basketLine);
        Task UpdateBasketLine(Guid basketId, BasketLine basketLine);
        Task RemoveBasketLine(Guid basketId, BasketLine basketLine);
        Task<IEnumerable<BasketLine>> GetAllBasketLines(Guid basketId);
        Task<Basket> Get(Guid basketId);
        Task<BasketLine> GetBasketLine(Guid basketLine, Guid eventId);
        Task<bool> Exists(Guid basketId);
        Task<bool> BasketLineExists(Guid basketId, Guid eventId);
    }
}

using System;
using System.Threading.Tasks;
using GloboTicket.Services.ShoppingBasket.DbContexts;
using GloboTicket.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.Services.ShoppingBasket.Repositories
{
    public class EFBasketRepository : IBasketRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public EFBasketRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task Add(Basket basket)
        {
            await _shoppingBasketDbContext.Baskets.AddAsync(basket);

            await _shoppingBasketDbContext.SaveChangesAsync();
        }

        public async Task AddBasketLine(Guid basketId, BasketLine basketLine)
        {
            basketLine.BasketId = basketId;

            await _shoppingBasketDbContext.BasketLines.AddAsync(basketLine);

            await _shoppingBasketDbContext.SaveChangesAsync();
        }

        public async Task UpdateBasketLine(Guid basketId, BasketLine basketLine)
        {
            await _shoppingBasketDbContext.SaveChangesAsync();
        }

        public Task<Basket> Get(Guid basketId)
        {
            return _shoppingBasketDbContext.Baskets.FirstOrDefaultAsync(it => it.BasketId == basketId);
        }

        public Task<BasketLine> GetBasketLine(Guid basketLine, Guid eventId)
        {
            return _shoppingBasketDbContext.BasketLines.FirstOrDefaultAsync(it => it.BasketId == basketLine && it.EventId == eventId);
        }

        public Task<bool> Exists(Guid basketId)
        {
            return _shoppingBasketDbContext.Baskets.AnyAsync(it => it.BasketId == basketId);
        }

        public Task<bool> BasketLineExists(Guid basketId, Guid eventId)
        {
            return _shoppingBasketDbContext.BasketLines.AnyAsync(it => it.BasketId == basketId && it.EventId == eventId);
        }
    }
}

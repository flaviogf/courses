using System;
using System.Threading.Tasks;
using GloboTicket.Services.ShoppingBasket.DbContexts;
using GloboTicket.Services.ShoppingBasket.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.Services.ShoppingBasket.Repositories
{
    public class EFEventRepository : IEventRepository
    {
        private readonly ShoppingBasketDbContext _shoppingBasketDbContext;

        public EFEventRepository(ShoppingBasketDbContext shoppingBasketDbContext)
        {
            _shoppingBasketDbContext = shoppingBasketDbContext;
        }

        public async Task Add(Event @event)
        {
            await _shoppingBasketDbContext.Events.AddAsync(@event);

            await _shoppingBasketDbContext.SaveChangesAsync();
        }

        public Task<bool> Exists(Guid eventId)
        {
            return _shoppingBasketDbContext.Events.AnyAsync(it => it.EventId == eventId);
        }
    }
}

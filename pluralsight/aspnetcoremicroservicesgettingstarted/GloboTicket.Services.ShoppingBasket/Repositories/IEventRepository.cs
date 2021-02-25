using System;
using System.Threading.Tasks;
using GloboTicket.Services.ShoppingBasket.Entities;

namespace GloboTicket.Services.ShoppingBasket.Repositories
{
    public interface IEventRepository
    {
        Task Add(Event @event);
        Task<bool> Exists(Guid eventId);
    }
}

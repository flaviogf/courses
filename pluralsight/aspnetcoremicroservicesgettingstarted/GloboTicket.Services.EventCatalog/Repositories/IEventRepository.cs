using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.Services.EventCatalog.Entities;

namespace GloboTicket.Services.EventCatalog.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll(Guid categoryId);
        Task<Event> Get(Guid eventId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GloboTicket.Services.EventCatalog.DbContexts;
using GloboTicket.Services.EventCatalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.Services.EventCatalog.Repositories
{
    public class EFEventRepository : IEventRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public EFEventRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }

        public async Task<IEnumerable<Event>> GetAll(Guid categoryId)
        {
            return await _eventCatalogDbContext.Events.Include(it => it.Category).Where(it => categoryId == Guid.Empty || it.CategoryId == categoryId).ToListAsync();
        }

        public Task<Event> Get(Guid eventId)
        {
            return _eventCatalogDbContext.Events.Include(it => it.Category).FirstOrDefaultAsync(it => it.EventId == eventId);
        }
    }
}

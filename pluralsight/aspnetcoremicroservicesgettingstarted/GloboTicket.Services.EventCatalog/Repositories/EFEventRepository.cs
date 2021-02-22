using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Event>> GetAll(Guid? categoryId = null)
        {
            var events = await _eventCatalogDbContext.Events
                .Include(it => it.Category)
                .Where(it => categoryId == null || it.CategoryId == categoryId)
                .ToListAsync();

            return events;
        }

        public async Task<Event> Get(Guid id)
        {
            var @event = await _eventCatalogDbContext.Events
                .Include(it => it.Category)
                .FirstOrDefaultAsync(it => it.Id == id);

            return @event;
        }
    }
}

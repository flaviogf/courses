using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.Services.EventCatalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.Services.EventCatalog.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly EventCatalogDbContext _eventCatalogDbContext;

        public EFCategoryRepository(EventCatalogDbContext eventCatalogDbContext)
        {
            _eventCatalogDbContext = eventCatalogDbContext;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _eventCatalogDbContext.Categories.ToListAsync();

            return categories;
        }
    }
}

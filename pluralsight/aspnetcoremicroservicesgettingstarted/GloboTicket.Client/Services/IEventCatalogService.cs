using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.Client.Models.Api;

namespace GloboTicket.Client.Services
{
    public interface IEventCatalogService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<Event>> GetAllEvents(Guid? categoryId = null);
        Task<Event> GetEvent(Guid id);
    }
}

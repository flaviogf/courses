using System.Collections.Generic;
using System.Threading.Tasks;
using GloboTicket.Services.EventCatalog.Entities;

namespace GloboTicket.Services.EventCatalog.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
    }
}

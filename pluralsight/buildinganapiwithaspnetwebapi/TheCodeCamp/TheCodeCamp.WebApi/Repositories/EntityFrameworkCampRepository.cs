using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TheCodeCamp.WebApi.Models;

namespace TheCodeCamp.WebApi.Repositories
{
    public class EntityFrameworkCampRepository : ICampRepository
    {
        private readonly TheCodeCampContext _context;

        public EntityFrameworkCampRepository(TheCodeCampContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Camp>> GetAllCampsAsync()
        {
            return await _context.Camps.ToListAsync();
        }

        public async Task<Camp> GetCampAsync(string moniker)
        {
            return await _context.Camps.FirstOrDefaultAsync(it => it.Moniker == moniker);
        }
    }
}
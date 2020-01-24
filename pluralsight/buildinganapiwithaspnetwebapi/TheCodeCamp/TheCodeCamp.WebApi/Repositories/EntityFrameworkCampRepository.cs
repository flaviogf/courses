using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public async Task<IEnumerable<Camp>> GetAllCampsAsync(bool includeTalks = false)
        {
            var query = _context.Camps.Include(it => it.Location);

            if (includeTalks)
            {
                query.Include(it => it.Talks.Select(talk => talk.Speaker));
            }

            return await query.ToListAsync();
        }

        public async Task<Camp> GetCampAsync(string moniker, bool includeTalks = false)
        {
            var query = _context.Camps.Include(it => it.Location);

            if (includeTalks)
            {
                query.Include(it => it.Talks.Select(talk => talk.Speaker));
            }

            return await query.FirstOrDefaultAsync(it => it.Moniker == moniker);
        }

        public async Task<IEnumerable<Camp>> GetAllCampsByEventDate(DateTime eventDate, bool includeTalks = false)
        {
            var query = _context.Camps.Include(it => it.Location);

            if (includeTalks)
            {
                query.Include(it => it.Talks.Select(talk => talk.Speaker));
            }

            return await query.Where(it => it.EventDate == eventDate).ToListAsync();
        }
    }
}
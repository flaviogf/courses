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
            IQueryable<Camp> query = _context.Camps;

            if (includeTalks)
            {
                query = query.Include(it => it.Talks.Select(talk => talk.Speaker));
            }

            query = query.Include(it => it.Location);

            return await query.ToListAsync();
        }

        public async Task<Camp> GetCampAsync(string moniker, bool includeTalks = false)
        {
            IQueryable<Camp> query = _context.Camps;

            if (includeTalks)
            {
                query = query.Include(it => it.Talks.Select(talk => talk.Speaker));
            }

            query = query.Include(it => it.Location);

            return await query.FirstOrDefaultAsync(it => it.Moniker == moniker);
        }

        public async Task<IEnumerable<Camp>> GetAllCampsByEventDateAsync(DateTime eventDate, bool includeTalks = false)
        {
            IQueryable<Camp> query = _context.Camps;

            if (includeTalks)
            {
                query = query.Include(it => it.Talks.Select(talk => talk.Speaker));
            }

            query = query.Include(it => it.Location);

            query = query.Where(it => it.EventDate == eventDate);

            return await query.ToListAsync();
        }

        public Task AddCampAsync(Camp camp)
        {
            _context.Camps.Add(camp);

            return Task.CompletedTask;
        }

        public async Task<bool> ExistsCampAsync(string moniker)
        {
            return await GetCampAsync(moniker) != null;
        }

        public Task DeleteCampAsync(Camp camp)
        {
            _context.Camps.Remove(camp);

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Talk>> GetTalksByMonikerAsync(string moniker, bool includeSpeaker = false)
        {
            IQueryable<Talk> query = _context.Talks;

            if (includeSpeaker)
            {
                query = query.Include(it => it.Speaker);
            }

            query = query.Where(it => it.Camp.Moniker == moniker);

            return await query.ToListAsync();
        }

        public async Task<Talk> GetTalkByMonikerAsync(string moniker, int id, bool includeSpeaker = false)
        {
            IQueryable<Talk> query = _context.Talks;

            if (includeSpeaker)
            {
                query = query.Include(it => it.Speaker);
            }

            return await query.FirstOrDefaultAsync(it => it.Id == id);
        }

        public Task AddTalkAsync(Talk talk)
        {
            _context.Talks.Add(talk);

            return Task.CompletedTask;
        }

        public Task<Speaker> GetSpeakerAsync(int id)
        {
            return _context.Speakers.Where(it => it.Id == id).FirstOrDefaultAsync();
        }

        public Task DeleteTalkAsync(Talk talk)
        {
            _context.Talks.Remove(talk);

            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
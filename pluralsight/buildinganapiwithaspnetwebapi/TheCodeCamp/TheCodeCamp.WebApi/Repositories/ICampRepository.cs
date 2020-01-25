using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheCodeCamp.WebApi.Models;

namespace TheCodeCamp.WebApi.Repositories
{
    public interface ICampRepository
    {
        Task<IEnumerable<Camp>> GetAllCampsAsync(bool includeTalks = false);

        Task<Camp> GetCampAsync(string moniker, bool includeTalks = false);

        Task<IEnumerable<Camp>> GetAllCampsByEventDateAsync(DateTime eventDate, bool includeTalks = false);

        Task AddCampAsync(Camp camp);

        Task<bool> ExistsCampAsync(string moniker);

        Task DeleteCampAsync(Camp camp);

        Task<IEnumerable<Talk>> GetTalksByMonikerAsync(string moniker, bool includeSpeaker = false);

        Task<Talk> GetTalkByMonikerAsync(string moniker, int id, bool includeSpeaker = false);

        Task AddTalkAsync(Talk talk);

        Task DeleteTalkAsync(Talk talk);

        Task<Speaker> GetSpeakerAsync(int id);

        Task SaveChangesAsync();
    }
}
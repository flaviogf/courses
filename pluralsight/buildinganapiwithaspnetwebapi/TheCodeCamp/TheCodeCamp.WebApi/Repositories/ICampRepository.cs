using System.Collections.Generic;
using System.Threading.Tasks;
using TheCodeCamp.WebApi.Models;

namespace TheCodeCamp.WebApi.Repositories
{
    public interface ICampRepository
    {
        Task<IEnumerable<Camp>> GetAllCampsAsync(bool includeTalks = false);

        Task<Camp> GetCampAsync(string moniker, bool includeTalks = false);
    }
}

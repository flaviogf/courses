using System.Collections.Generic;
using System.Threading.Tasks;
using TheCodeCamp.WebApi.Models;

namespace TheCodeCamp.WebApi.Repositories
{
    public interface ICampRepository
    {
        Task<IEnumerable<Camp>> GetAllCampsAsync();

        Task<Camp> GetCampAsync(string moniker);
    }
}

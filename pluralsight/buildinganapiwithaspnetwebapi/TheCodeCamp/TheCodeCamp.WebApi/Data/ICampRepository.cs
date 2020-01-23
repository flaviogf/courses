using System.Collections.Generic;
using System.Threading.Tasks;
using TheCodeCamp.WebApi.Models;

namespace TheCodeCamp.WebApi.Data
{
    public interface ICampRepository
    {
        Task<IEnumerable<Camp>> GetAllCampsAsync();
    }
}

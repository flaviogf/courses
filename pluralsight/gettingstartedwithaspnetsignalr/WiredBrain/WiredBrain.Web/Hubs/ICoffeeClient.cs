using System.Threading.Tasks;
using WiredBrain.Web.Models;

namespace WiredBrain.Web.Hubs
{
    public interface ICoffeeClient
    {
        Task OnOrderUpdated(Order order);
    }
}

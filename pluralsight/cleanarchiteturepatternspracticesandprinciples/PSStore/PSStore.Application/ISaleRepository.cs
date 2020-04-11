using PSStore.Domain.Sales;
using System.Linq;
using System.Threading.Tasks;

namespace PSStore.Application
{
    public interface ISaleRepository
    {
        IQueryable<Sale> GetAll();

        Task Add(Sale sale);
    }
}

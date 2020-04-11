using PSStore.Domain.Sales;
using System.Threading.Tasks;

namespace PSStore.Application
{
    public interface ISaleRepository
    {
        Task Add(Sale sale);
    }
}

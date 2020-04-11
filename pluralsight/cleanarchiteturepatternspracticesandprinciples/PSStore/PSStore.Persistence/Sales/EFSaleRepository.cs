using PSStore.Application;
using PSStore.Domain.Sales;
using System.Linq;
using System.Threading.Tasks;

namespace PSStore.Persistence.Sales
{
    public class EFSaleRepository : ISaleRepository
    {
        private readonly PSStoreDbContext _context;

        public EFSaleRepository(PSStoreDbContext context)
        {
            _context = context;
        }

        public async Task Add(Sale sale)
        {
            await _context.AddAsync(sale);
        }

        public IQueryable<Sale> GetAll()
        {
            return _context.Sales;
        }
    }
}

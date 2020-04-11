using PSStore.Application;
using System.Threading.Tasks;

namespace PSStore.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PSStoreDbContext _context;

        public UnitOfWork(PSStoreDbContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

using System.Threading.Tasks;

namespace PSStore.Application
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}

using System.Threading.Tasks;
using TodoList.Core;

namespace TodoList.Service
{
    public interface ITodoRepository
    {
        Task Add(Todo todo);

        Task<int> Count();
    }
}
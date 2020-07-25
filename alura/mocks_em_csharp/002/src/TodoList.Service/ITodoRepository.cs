using CSharpFunctionalExtensions;
using System.Threading.Tasks;
using TodoList.Core;

namespace TodoList.Service
{
    public interface ITodoRepository
    {
        Task<Result> Add(Todo todo);
    }
}

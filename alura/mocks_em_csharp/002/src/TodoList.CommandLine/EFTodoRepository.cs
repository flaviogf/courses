using CSharpFunctionalExtensions;
using System.Threading.Tasks;
using TodoList.Core;
using TodoList.Service;

namespace TodoList.CommandLine
{
    public class EFTodoRepository : ITodoRepository
    {
        private readonly ApplicationContext _context;

        public EFTodoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Result> Add(Todo todo)
        {
            await _context.Todos.AddAsync(todo);

            return Result.Success();
        }
    }
}

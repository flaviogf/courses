using System.Threading.Tasks;
using TodoList.Core;

namespace TodoList.Service
{
    public class CreateTodoHandler
    {
        private readonly ITodoRepository _todoRepository;

        public CreateTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task Execute(CreateTodo createTodo)
        {
            var todo = new Todo(createTodo.Id, createTodo.Title, createTodo.Deadline);

            await _todoRepository.Add(todo);
        }
    }
}
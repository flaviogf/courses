using CSharpFunctionalExtensions;
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

        public Task<Result> Execute(CreateTodo createTodo)
        {
            var todo = new Todo(createTodo.Id, createTodo.Title, createTodo.Deadline);

            return _todoRepository.Add(todo);
        }
    }
}

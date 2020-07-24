using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Core;
using TodoList.Service;

namespace TodoList.Test
{
    internal class FakeTodoRepository : ITodoRepository
    {
        private readonly IList<Todo> todos = new List<Todo>();

        public Task Add(Todo todo)
        {
            todos.Add(todo);

            return Task.CompletedTask;
        }

        public Task<int> Count()
        {
            return Task.FromResult(todos.Count);
        }
    }
}
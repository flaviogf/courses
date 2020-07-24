using System;
using System.Threading.Tasks;
using TodoList.Core;
using TodoList.Service;
using Xunit;

namespace TodoList.Test
{
    public class CreateTodoHandlerExecute
    {
        [Fact]
        public async Task ShouldAddANewTodo()
        {
            var todoRepository = new FakeTodoRepository();

            var handler = new CreateTodoHandler(todoRepository);

            var createTodo = new CreateTodo
            {
                Id = Guid.NewGuid(),
                Title = "Test",
                Deadline = new DateTime(year: 2020, month: 6, day: 13)
            };

            await handler.Execute(createTodo);

            var count = await todoRepository.Count();

            Assert.Equal(1, count);
        }
    }
}

using CSharpFunctionalExtensions;
using Moq;
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
        public async Task ShouldReturnSuccess()
        {
            var todoRepository = new Mock<ITodoRepository>();

            var handler = new CreateTodoHandler(todoRepository.Object);

            var createTodo = new CreateTodo
            {
                Id = Guid.NewGuid(),
                Title = "I have todo something important, I just not know what",
                Deadline = new DateTime(year: 2020, month: 6, day: 13)
            };

            var result = await handler.Execute(createTodo);

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public async Task WhenAddHasFailedShouldReturnFailure()
        {
            var todoRepository = new Mock<ITodoRepository>();

            todoRepository.Setup(it => it.Add(It.IsAny<Todo>())).Returns(() => Task.FromResult(Result.Failure("Something has gone wrong")));

            var handler = new CreateTodoHandler(todoRepository.Object);

            var createTodo = new CreateTodo
            {
                Id = Guid.NewGuid(),
                Title = "I have todo something important, I just not know what",
                Deadline = new DateTime(year: 2020, month: 6, day: 13)
            };

            var result = await handler.Execute(createTodo);

            Assert.True(result.IsFailure);
        }
    }
}

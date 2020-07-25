using System;
using System.Threading.Tasks;
using TodoList.Core;
using TodoList.Service;

namespace TodoList.CommandLine
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var context = new ApplicationContext();

            var todoRepository = new EFTodoRepository(context);

            var handler = new CreateTodoHandler(todoRepository);

            Console.WriteLine("Todo title:");

            var title = Console.ReadLine();

            var createTodo = new CreateTodo
            {
                Id = Guid.NewGuid(),
                Title = title,
                Deadline = DateTime.Now.AddDays(1)
            };

            var result = await handler.Execute(createTodo);

            if (result.IsFailure)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(result.Error);

                Console.ResetColor();

                return;
            }

            await context.SaveChangesAsync();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Todo has been added");

            Console.ResetColor();
        }
    }
}

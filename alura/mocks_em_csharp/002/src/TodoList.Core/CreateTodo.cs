using System;

namespace TodoList.Core
{
    public class CreateTodo
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime Deadline { get; set; }
    }
}

using System;

namespace TodoList.Core
{
    public class Todo
    {
        public Todo(Guid id, string title, DateTime deadline)
        {
            Id = id;
            Title = title;
            Deadline = deadline;
        }

        public Guid Id { get; }

        public string Title { get; }

        public DateTime Deadline { get; }
    }
}
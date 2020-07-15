namespace Todo
{
    public class Task
    {
        public Task(int id, string title, bool done)
        {
            Id = id;
            Title = title;
            Done = done;
        }

        public int Id { get; }

        public string Title { get; }

        public bool Done { get; }

        public override string ToString() => $"[{(Done ? "Done" : "Todo")}] {Id} {Title}";
    }
}

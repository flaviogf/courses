namespace Tasks
{
    public class Task
    {
        public Task(string id, string title, bool done)
        {
            Id = id;
            Title = title;
            Done = done;
        }

        public string Id { get; }

        public string Title { get; }

        public bool Done { get; }

        public override string ToString() => $"[{(Done ? "Done" : "To Do")}]\t {Id} {Title}";
    }
}

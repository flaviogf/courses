namespace AluraCar.TableView.Models
{
    public abstract class Vehicle
    {
        public abstract string Name { get; }

        public abstract decimal Price { get; }

        public Snapshot Snapshot()
        {
            return new Snapshot(this);
        }
    }
}

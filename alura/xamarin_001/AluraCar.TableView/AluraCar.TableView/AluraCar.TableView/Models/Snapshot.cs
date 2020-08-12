namespace AluraCar.TableView.Models
{
    public class Snapshot
    {
        private readonly Vehicle _vehicle;

        public Snapshot(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public Vehicle Restore()
        {
            return _vehicle;
        }
    }
}

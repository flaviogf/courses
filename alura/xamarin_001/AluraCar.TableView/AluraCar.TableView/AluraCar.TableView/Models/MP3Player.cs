namespace AluraCar.TableView.Models
{
    public class MP3Player : AccessoryDecorator
    {
        private readonly Vehicle _vehicle;

        public MP3Player(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public override string Name => $"{_vehicle.Name}, MP3 Player";

        public override decimal Price => _vehicle.Price + 500;
    }
}

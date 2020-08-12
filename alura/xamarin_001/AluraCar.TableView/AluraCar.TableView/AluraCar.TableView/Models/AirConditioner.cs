namespace AluraCar.TableView.Models
{
    public class AirConditioner : AccessoryDecorator
    {
        private readonly Vehicle _vehicle;

        public AirConditioner(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public override string Name => $"{_vehicle.Name}, Air Conditioner";

        public override decimal Price => _vehicle.Price + 1_000;
    }
}

namespace AluraCar.TestDrive.Models
{
    public class Brake : AccessoryDecorator
    {
        private readonly Vehicle _vehicle;

        public Brake(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public override string Name => $"{_vehicle.Name}, Brake";

        public override decimal Price => _vehicle.Price + 800;
    }
}

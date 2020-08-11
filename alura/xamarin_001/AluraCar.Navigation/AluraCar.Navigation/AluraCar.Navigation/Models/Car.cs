namespace AluraCar.Navigation.Models
{
    public class Car
    {
        public Car(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public decimal Price { get; }
    }
}

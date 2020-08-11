namespace AluraCar.LabelSpan
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

        public override string ToString()
        {
            return Name;
        }
    }
}

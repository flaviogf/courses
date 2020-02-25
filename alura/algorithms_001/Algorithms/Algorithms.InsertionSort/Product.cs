namespace Algorithms.InsertionSort
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public decimal Price { get; }

        public override string ToString()
        {
            return $"Product[Name={Name}, Price={Price:C}]";
        }
    }
}

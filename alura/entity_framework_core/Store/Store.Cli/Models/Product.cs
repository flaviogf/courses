namespace Store.Cli.Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(string name, string category)
        {
            Name = name;
            Category = category;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public override string ToString() => $"Product[Id={Id}, Name={Name}, Category={Category}]";
    }
}

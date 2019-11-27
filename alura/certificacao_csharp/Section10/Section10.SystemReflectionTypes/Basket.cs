using System.Collections.Generic;

namespace Section10.SystemReflectionTypes
{
    public class Basket
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public IList<Product> Products { get; set; }
    }
}

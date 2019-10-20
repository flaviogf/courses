using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Web.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public DateTime DueDate { get; set; }

        public Customer Customer { get; set; }

        public IList<CartItem> Items { get; set; } = new List<CartItem>();
    }
}

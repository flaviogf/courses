using System.Collections.Generic;

namespace CasaDoCodigo.Web.ViewModels.Order
{
    public class OrderViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public IEnumerable<OrderItemViewModel> Products { get; set; }
    }
}

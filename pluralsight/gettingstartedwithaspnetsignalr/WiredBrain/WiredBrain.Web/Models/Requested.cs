namespace WiredBrain.Web.Models
{
    public class Requested : IState
    {
        public string Name => "Requested";

        public Order Next(Order order)
        {
            return new Order(order.Id, order.Product, order.Quantity, new InProgress());
        }
    }
}
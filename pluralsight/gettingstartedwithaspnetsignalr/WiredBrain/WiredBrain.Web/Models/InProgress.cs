namespace WiredBrain.Web.Models
{
    public class InProgress : IState
    {
        public string Name => "InProgress";

        public Order Next(Order order)
        {
            return new Order(order.Id, order.Product, order.Quantity, new Finished());
        }
    }
}
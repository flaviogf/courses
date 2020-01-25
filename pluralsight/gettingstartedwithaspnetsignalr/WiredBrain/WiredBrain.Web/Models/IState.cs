namespace WiredBrain.Web.Models
{
    public interface IState
    {
        string Name { get; }

        Order Next(Order order);
    }
}
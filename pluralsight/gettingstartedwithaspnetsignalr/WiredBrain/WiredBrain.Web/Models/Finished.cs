namespace WiredBrain.Web.Models
{
    public class Finished : IState
    {
        public string Name => "Finished";

        public Order Next(Order order)
        {
            throw new OrderAlreadyFinishedException();
        }
    }
}
using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;
using WiredBrain.Web.Models;

namespace WiredBrain.Web.Hubs
{
    public class CoffeeHub : Hub<ICoffeeClient>
    {
        public async Task Process(string product, int quantity)
        {
            var order = new Order(Guid.NewGuid(), product, quantity);

            try
            {
                while (true)
                {
                    await Clients.All.OnOrderUpdated(order);

                    order = order.Process();

                    await Task.Delay(1000);
                }
            }
            catch (OrderAlreadyFinishedException) { }
        }
    }
}
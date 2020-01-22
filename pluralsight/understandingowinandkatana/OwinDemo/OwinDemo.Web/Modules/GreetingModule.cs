using Nancy;

namespace OwinDemo.Web.Modules
{
    public class GreetingModule : NancyModule
    {
        public GreetingModule()
        {
            Get("/greeting", args =>
            {
                return "Hello, world.";
            });
        }
    }
}
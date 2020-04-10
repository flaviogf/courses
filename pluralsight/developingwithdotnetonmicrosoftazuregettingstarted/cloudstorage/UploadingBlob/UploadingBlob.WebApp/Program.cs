using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UploadingBlob.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(it => it.UseStartup<Startup>());
        }
    }
}

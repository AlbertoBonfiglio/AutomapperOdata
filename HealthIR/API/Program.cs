
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using HealthIR.Core.Data;
namespace HealthIR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
            .Build()
            .MigrateDatabase()
            .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

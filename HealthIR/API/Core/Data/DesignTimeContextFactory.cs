using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HealthIR.Core.Data
{

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HealthDbContext>
    {
        public HealthDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<HealthDbContext>();
            
            builder.UseLazyLoadingProxies()
                        //.UseMySql (dbConnString);  
                        .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=health;Integrated Security=True");
            return new HealthDbContext(builder.Options);
        }
    }
}
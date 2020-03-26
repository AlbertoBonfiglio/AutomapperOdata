using HealthIR.Core.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HealthIR.Core.Data
{
    public static class MigrationManager
    {
        public static IWebHost MigrateDatabase(this IWebHost host)
        {
            // done this way we can put the migrations in another assembly if we so chose
            using (var serviceScope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                var ctx = serviceScope.ServiceProvider.GetService<HealthDbContext>();
                if (!ctx.AllMigrationsApplied()) {
                    ctx.Database.Migrate();
                    if (!isProduction()){
                        var seeder = new DataSeeder(ctx);
                        seeder.Seed();
                    }
                }
            }
            return host;
        }

        private static bool isProduction() {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine("***************************************** ENV: " + Environments.Production);
            return environment == Environments.Production;    
        }
    }
}
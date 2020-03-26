/*
    This class exposes the Database context used by the application. 
    it exposes an incidents and a configuration dataset
    Database creation follows the Entity Framework Code first model
    After changing context or models a migration should be performed.
    The syntax is: dotnet ef migrations add <name of migration>
    Afterward any changes to the database script (e.g altering a constraint or check, or creating a stored proc)
    should be done in the up method of the migration file. Code to reverse the changes should be placed in the 
    down method.
    Subsequently the development database can be manually update by calling: dotnet ef database update 
*/

using System;
using System.Linq;
using System.Threading.Tasks;
using Benton.EF.Core;
using Benton.HealthIR.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace HealthIR.Core.Data {
    public class HealthDbContext : DbContext {
        public  DbSet<Report> Incidents { get; set; } = null!;
        public  DbSet<Benton.HealthIR.Models.Action> Actions { get; set; } = null!;
        public DbSet<Attachment> Attachments { get; set; } = null!;
        public DbSet<IncidentType> IncidentTypes { get; set; } = null!;
        public DbSet<PersonType> PersonTypes { get; set; } = null!;
        public DbSet<EventType> EventTypes { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<Settings> Settings { get; set; } = null!;


        public HealthDbContext (DbContextOptions<HealthDbContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating (builder);

            // TODO use refelection to configure configurations
            /*
            var typesToRegister = Assembly.GetAssembly(typeof(YourDbContext)).GetTypes()
              .Where(type => type.Namespace != null
                && type.Namespace.Equals(typeof(YourDbContext).Namespace))
              .Where(type => type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister) {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            */

            builder.ApplyConfiguration(new ReportConfiguration ());
            builder.ApplyConfiguration(new ActionConfiguration());
            builder.ApplyConfiguration(new IncidentTypeConfiguration());
            builder.ApplyConfiguration(new EventTypeConfiguration());
            builder.ApplyConfiguration(new PersonTypeConfiguration());
            builder.ApplyConfiguration(new IncidentEventTypeConfiguration());
            builder.ApplyConfiguration(new LocationConfiguration());
            builder.ApplyConfiguration (new SettingConfiguration ());
        }


        /// <summary>  
        /// Overriding Save Changes  
        /// </summary>  
        /// <returns></returns>  
        public int SaveChanges(string userName = "SYSTEM") {
            FillAuditFields(userName);
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken), string userName = "SYSTEM" ){
            FillAuditFields(userName);
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void FillAuditFields(string userName = "SYSTEM") {
            var selectedEntityList = ChangeTracker.Entries()
                                    .Where(x => x.Entity is Entity<Guid> &&
                                    (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in selectedEntityList) {

                if (entity.State == EntityState.Added) {
                    var item = (Entity<Guid>)entity.Entity;

                    item.Id = (item.Id == Guid.Empty) ? new SequentialGuidValueGenerator().Next(null) : item.Id;
                    ((Entity<Guid>)entity.Entity).CreatedBy = userName;
                    ((Entity<Guid>)entity.Entity).CreatedDate = new DateTimeOffset(DateTime.UtcNow);
                } else {
                    ((Entity<Guid>)entity.Entity).ModifiedBy = userName;
                    ((Entity<Guid>)entity.Entity).ModifiedDate = new DateTimeOffset(DateTime.UtcNow);
                }
            }
        }
    }
}
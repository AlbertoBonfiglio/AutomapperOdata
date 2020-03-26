using System;
using Benton.EF.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benton.HealthIR.Models
{
    public class Location: Entity<Guid> 
    {
        public string Name {get; set;} = null!;
        public string Description { get; set; } = "";

    }

    public class LocationConfiguration: EntityConfiguration<Location, Guid>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            base.Configure(builder);
            
            builder.Property(p => p.Name)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(256);

            builder.Property(p => p.Type).IsRequired()
                .HasDefaultValue("Location")
                .HasMaxLength(24);
                
            builder.HasIndex(p => new { p.Name }).IsUnique(true);

            builder.ToTable("Locations"); // change to get from config

            builder.HasData(
                new EventType { Id = Guid.NewGuid(), Name = "BHC" , CreatedBy = "SYSTEM" , CreatedDate = DateTimeOffset.Now },
                new EventType { Id = Guid.NewGuid(), Name = "ELHC", CreatedBy = "SYSTEM", CreatedDate = DateTimeOffset.Now  },
                new EventType { Id = Guid.NewGuid(), Name = "LHC", CreatedBy = "SYSTEM" , CreatedDate = DateTimeOffset.Now },
                new EventType { Id = Guid.NewGuid(), Name = "MHC", CreatedBy = "SYSTEM" , CreatedDate = DateTimeOffset.Now },
                new EventType { Id = Guid.NewGuid(), Name = "AHC", CreatedBy = "SYSTEM" , CreatedDate = DateTimeOffset.Now },
                new EventType { Id = Guid.NewGuid(), Name = "SHHC", CreatedBy = "SYSTEM" , CreatedDate = DateTimeOffset.Now },
                new EventType { Id = Guid.NewGuid(), Name = "SUNSET", CreatedBy = "SYSTEM", CreatedDate = DateTimeOffset.Now  }
            );
        }
    }

}
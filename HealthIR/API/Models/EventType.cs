using System;
using Benton.EF.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benton.HealthIR.Models
{
    public class EventType: Entity<Guid> 
    {
        public string Name {get; set;} = null!;
        public string Description { get; set; } = "";

    }

    public class EventTypeConfiguration: EntityConfiguration<EventType, Guid>
    {
        public override void Configure(EntityTypeBuilder<EventType> builder) {
            base.Configure(builder);
            
            builder.Property(p => p.Name)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(256);

            builder.Property(p => p.Type).IsRequired()
                .HasDefaultValue("EventType")
                .HasMaxLength(24);

            builder.ToTable("EventTypes"); // change to get from config

            builder.HasData(
                new EventType { Id = Guid.NewGuid(),  Name = "Medication Error" , CreatedBy = "SYSTEM", CreatedDate = DateTimeOffset.Now },
                new EventType { Id = Guid.NewGuid(), Name = "Lab Error", CreatedBy = "SYSTEM", CreatedDate = DateTimeOffset.Now },
                new EventType { Id = Guid.NewGuid(),  Name = "Medical Alert", CreatedBy = "SYSTEM", CreatedDate = DateTimeOffset.Now }
            );
        }
    }

}
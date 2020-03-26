using System;
using Benton.EF.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benton.HealthIR.Models
{
    public class IncidentType : Entity<Guid>  {
        public string Name {get; set;} = null!;
        public string Description { get; set; } = "";
        public Boolean IsCritical { get; set; } = false;
    }

    public class IncidentTypeConfiguration: EntityConfiguration<IncidentType, Guid>
    {
        public override void Configure(EntityTypeBuilder<IncidentType> builder) {

            base.Configure(builder);
            
            builder.Property(p => p.Name)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(256);

            builder.Property(p => p.IsCritical)
                .IsRequired();

            // Entity
            builder.Property(p => p.Type).IsRequired()
                .HasDefaultValue("IncidentType")
                .HasMaxLength(24);

            builder.HasIndex(p => new { p.Name }).IsUnique(true);

            builder.ToTable("IncidentTypes"); // change to get from config

            builder.HasData(
                new IncidentType { Id = Guid.NewGuid(), Name = "Incident", CreatedBy = "SYSTEM" , CreatedDate = DateTimeOffset.Now },
                new IncidentType { Id = Guid.NewGuid(), Name = "Near Miss", CreatedBy = "SYSTEM" , CreatedDate = DateTimeOffset.Now }
            );
        }
    }

}
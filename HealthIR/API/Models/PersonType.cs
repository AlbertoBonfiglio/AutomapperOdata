using System;
using Benton.EF.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benton.HealthIR.Models
{
    public class PersonType: Entity<Guid> 
    {
        public string Name {get; set;} = null!; 
        public string Description { get; set; } = "";
        
    }

    public class PersonTypeConfiguration : EntityConfiguration<PersonType, Guid> {
        public override void Configure(EntityTypeBuilder<PersonType> builder) {
            base.Configure(builder);
            
            builder.Property(p => p.Name)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(256)
                .IsRequired();

            // Entity
            builder.Property(p => p.Type).IsRequired()
                .HasDefaultValue("PersonType")
                .HasMaxLength(24);

            builder.HasIndex(p => new { p.Name }).IsUnique(true);

            builder.ToTable("PersonTypes"); // change to get from config

            builder.HasData(
                new PersonType { Id = Guid.NewGuid(), Name = "Employee", CreatedBy = "SYSTEM" , CreatedDate = DateTimeOffset.Now },
                new PersonType { Id = Guid.NewGuid(), Name = "Visitor", CreatedBy = "SYSTEM" , CreatedDate = DateTimeOffset.Now },
                new PersonType { Id = Guid.NewGuid(), Name = "Client/Patient", CreatedBy = "SYSTEM", CreatedDate = DateTimeOffset.Now  }
            );

        }
    }

}
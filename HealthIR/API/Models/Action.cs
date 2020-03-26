using Benton.EF.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Benton.HealthIR.Models {
    public class Action : Entity<Guid> {
        public string EmployeeId {get; set;} = null!;
        public string FirstName {get; set;} = null!;
        public string LastName {get; set;} = null!;
        public DateTimeOffset Date { get; set; } 
        public string Content {get; set;} = null!;
        public bool Complete { get; set; } = false;
        public virtual Report Report { get; set; }

        public Action () {
            Type = "IncidentAction";
        }
    }

    public class ActionConfiguration : EntityConfiguration<Action, Guid> {
        public override void Configure (EntityTypeBuilder<Action> builder) {
            builder.Property(p => p.EmployeeId)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.Date)
                .IsRequired();

            builder.Property(p => p.Content)
                .IsRequired();

            builder.Property(p => p.Complete)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(p => p.Type).IsRequired()
                .HasDefaultValue("IncidentAction")
                .HasMaxLength(24);
            
            builder.HasIndex(p => new { p.Date })
                .IsUnique(false);
            builder.HasIndex(p => new { p.Complete})
                .IsUnique(false);

            builder.HasOne(p => p.Report)
                .WithMany(p => p.Actions)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable ("Actions"); // change to get from config
        }
    }

}
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Benton.EF.Core;

namespace Benton.HealthIR.Models {
    public class Report : Entity<Guid> {
        public string EmployeeId {get; set;} = null!;
        public string FirstName {get; set;} = null!;
        public string LastName {get; set;} = null!;
        public DateTimeOffset Date { get; set; }
        public string MRN { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Content {get; set;} = null!;
        public Guid IncidentTypeId { get; set; }
        public virtual IncidentType IncidentType { get; set; } = null!;
        public Guid PersonTypeId { get; set; }
        public virtual PersonType PersonType { get; set; } = null!;
        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<IncidentEventType> IncidentEventTypes { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        public Boolean Finalized { get; set; } = false;
        public int Status { get; set; } = 0;

        public Report () {
            Type = "Report";
            Actions = new List<Action> ();
            Attachments = new List<Attachment>();
            IncidentEventTypes = new List<IncidentEventType>();
        }
    }
    public class ReportConfiguration : IEntityTypeConfiguration<Report> {
        public void Configure (EntityTypeBuilder<Report> builder) {
            // Primary Key
            builder.HasKey (p => p.Id);
            builder.Property (p => p.Id)
            .ValueGeneratedOnAdd ();

            builder.Property(p => p.EmployeeId)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasMaxLength(24);
            
            builder.Property(p => p.Date)
                .IsRequired();

            builder.Property(p => p.Content)
                .IsRequired();

            builder.Property(p => p.Finalized)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(p => p.MRN)
                .HasMaxLength(24);

            // Entity
            builder.Property(p => p.Type)
                .IsRequired()
                .HasDefaultValue("IncidentReport")
                .HasMaxLength(24);

            builder.HasOne(p => p.IncidentType).WithMany();
            builder.HasOne(p => p.PersonType).WithMany();
            builder.HasOne(p => p.Location).WithMany();

            builder.HasIndex(p => new { p.EmployeeId }).IsUnique(false);
            builder.HasIndex(p => new { p.Date}).IsUnique(false);
           
            builder.ToTable ("Incidents"); // change to get from config

        }

    }

}
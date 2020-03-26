using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benton.HealthIR.Models
{
    public class IncidentEventType
    {
        public Guid ReportId {get; set;}
        public virtual Report Report { get; set; } = null!;
        public Guid EventTypeId { get; set; }
        public virtual EventType EventType { get; set; } = null!;
    }

    public class IncidentEventTypeConfiguration : IEntityTypeConfiguration<IncidentEventType>
    {
        public void Configure(EntityTypeBuilder<IncidentEventType> builder)
        {
            builder.HasKey(p => new {p.ReportId, p.EventTypeId});

            builder.HasOne(p => p.Report)
                .WithMany(i => i.IncidentEventTypes)
                .HasForeignKey(p => p.ReportId); 
            
            builder.HasOne(p => p.EventType)
                .WithMany()
                .HasForeignKey(p => p.EventTypeId);
            
            builder.ToTable("IncidentEventType"); // change to get from config
        }
    }

}
using System;
using Benton.EF.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benton.HealthIR.Models
{
    public class Attachment: Entity<Guid> 
    {
        public string MediaType {get; set;} = null!; 
        public string Url { get; set; } = null!;
        public virtual Report Report { get; set; }
    }

    public class AttachmentConfiguration : EntityConfiguration<Attachment, Guid> {
        public override void Configure(EntityTypeBuilder<Attachment> builder) {
            base.Configure(builder);
            
            builder.Property(p => p.MediaType)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.Url)
                .HasMaxLength(128)
                .IsRequired();

            // Entity
            builder.Property(p => p.Type).IsRequired()
                .HasDefaultValue("Attachment")
                .HasMaxLength(24);
            
            builder.HasOne(p => p.Report)
                .WithMany(p => p.Attachments)
                .OnDelete(DeleteBehavior.Cascade);    

            builder.ToTable("Attachments"); // change to get from config
        }
    }

}
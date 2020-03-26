
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benton.EF.Core {

    public interface IEntityConfiguration<T, K> : IEntityTypeConfiguration<T>
    where T : class, IEntity<K>
    {
        public new void Configure(EntityTypeBuilder<T> builder);
    }

    public class EntityConfiguration<T, K> : IEntityConfiguration<T, K>
    where T: class, IEntity<K> 
    {
        public virtual void Configure(EntityTypeBuilder<T> builder) {

            // Primary Key
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Type)
            .IsRequired()
            .HasMaxLength(48);

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(48)
                .IsRequired();

            builder.Property(p => p.CreatedDate)
                .IsRequired().ValueGeneratedOnAdd();

            builder.Property(p => p.ModifiedBy)
                .HasMaxLength(48);

            builder.Property(p => p.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.Deleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasIndex(p => new { p.Type })
                .IsUnique(false);
       
            builder.HasIndex(p => new { p.Deleted })
                .IsUnique(false);
        }
    }
}
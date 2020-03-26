using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Benton.EF.Core
{
    public abstract class Entity<T> : IEntity<T> {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        object IEntity.Id {
            get { return this.Id; }
            set { this.Id = (T)value; }
        }

        [Required]
        [MaxLength(24)]
        public string Type { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTimeOffset CreatedDate { get; set; }

        [Required]
        [MaxLength(24)]
        public string CreatedBy { get; set; }

        [MaxLength(24)]
        public string ModifiedBy { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }

        [Required] 
        public bool Deleted { get; set; } 
        
        [Timestamp]
        public byte[] RowVersion { get; set; }
        
    }
}
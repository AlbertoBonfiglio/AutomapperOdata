using System;

namespace Benton.EF.Core {
    public interface IModifiableEntity {
        string Type { get; set; }    
    }

    public interface IEntity : IModifiableEntity {
        object Id { get; set; }
        string Type { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        bool Deleted { get; set; }
        byte[] RowVersion { get; set; }
    }

    public interface IEntity<T> : IEntity {
        new T Id { get; set; }
    }
}
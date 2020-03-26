using System;

namespace Benton.HealthIR.Models
{
    public class PersonTypeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Deleted { get; set; } = false;
    }

}
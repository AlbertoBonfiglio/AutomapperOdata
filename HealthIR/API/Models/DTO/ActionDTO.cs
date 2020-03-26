using System;

namespace Benton.HealthIR.Models
{
    public class ActionDTO
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTimeOffset Date { get; set; }
        public string Content { get; set; } = null!;
        public bool Complete { get; set; } = false;
        public bool Deleted { get; set; } = false;

        public ActionDTO(){}
    }

}
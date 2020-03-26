using System;
using System.Collections.Generic;

namespace Benton.HealthIR.Models
{
    public class ReportDTO
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTimeOffset Date { get; set; }
        public string MRN { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTimeOffset CreatedDate { get; set; }
        public IncidentTypeDTO IncidentType { get; set; } = null!;
        public PersonTypeDTO PersonType { get; set; } = null!;
        public LocationDTO Location { get; set; } = null!;
        public ICollection<EventTypeDTO> EventTypes { get; set; } = new List<EventTypeDTO>();
        public ICollection<AttachmentDTO> Attachments { get; set; } = new List<AttachmentDTO>();
        public ICollection<ActionDTO> Actions { get; set; } = new List<ActionDTO>();
        public Boolean Finalized { get; set; } = false;
        public int Status { get; set; } = 0;
        public bool Deleted { get; set; } = false;
    }

}
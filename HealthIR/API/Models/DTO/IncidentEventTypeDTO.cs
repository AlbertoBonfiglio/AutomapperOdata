using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benton.HealthIR.Models
{
    public class IncidentEventTypeDTO
    {
        public Guid ReportId {get; set;}
        public virtual Report Report { get; set; } = null!;
        public Guid EventTypeId { get; set; }
        public virtual EventType EventType { get; set; } = null!;
    }
   
}
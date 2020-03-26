/*
    This class derives from the generic dynamicTicket class. 
    It is basically a wrapper around the actual data (stored as a JSON object) 
    
    The IncidentReportConfiguration is the fluent description of the model for Entity Framework
    code first approach
*/

using System;

namespace Benton.HealthIR.Models
{
    public  class AttachmentDTO
    {
        public Guid Id { get; set; }
        public string MediaType { get; set; } = null!;
        public string Url { get; set; } = null!;
        public bool Deleted { get; set; } = false;

    }
}
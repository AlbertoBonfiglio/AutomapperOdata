using System.Collections.Generic;

namespace Benton.HealthIR.Models
{
    public class OptionCollectionDTO
    {
        public IList<LocationDTO> Locations { get; set; } = null!;
        public IEnumerable<PersonTypeDTO> PersonTypes { get; set; } = null!;
        public IEnumerable<IncidentTypeDTO> IncidentTypes { get; set; } = null!;
        public IEnumerable<EventTypeDTO> EventTypes { get; set; } = null!;
    }


}
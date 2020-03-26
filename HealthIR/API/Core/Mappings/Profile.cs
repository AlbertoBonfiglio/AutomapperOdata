using System.Linq;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Benton.HealthIR.Models;

namespace HealthIR.Core.Mappings {
    
    public class IncidentReportProfile : Profile {
        public IncidentReportProfile() {
            CreateMap<Report, ReportDTO>()
            .ForMember(dto => dto.EventTypes, opt => opt
                .MapFrom(src => src.IncidentEventTypes.Select(i => i.EventType)));
            
            CreateMap<ReportDTO, Report>()
            // this is to prevent actions to be submitted up
            .ForMember(d => d.Location, opt => opt.Ignore())
            .ForMember(d => d.PersonType, opt => opt.Ignore())
            .ForMember(d => d.IncidentType, opt => opt.Ignore())
            .ForMember(d => d.LocationId, opt => opt.MapFrom(src => src.Location.Id))
            .ForMember(d => d.PersonTypeId, opt => opt.MapFrom(src => src.PersonType.Id))
            .ForMember(d => d.IncidentTypeId, opt => opt.MapFrom(src => src.IncidentType.Id))
            .ForMember(d => d.IncidentEventTypes, opt => opt
                .MapFrom((src, dst) => src.EventTypes
                    .Select(eventType => new IncidentEventType() {ReportId = dst.Id, EventTypeId = eventType.Id })
                ))
            .ForMember(d => d.CreatedDate, opt => opt.Ignore())
            .EqualityComparison((odto, o) => odto.Id == o.Id);

            CreateMap<IncidentType, IncidentTypeDTO>();
            CreateMap<IncidentTypeDTO, IncidentType>()
            .EqualityComparison((odto, o) => odto.Id == o.Id);

            CreateMap<Location, LocationDTO>();
            CreateMap<LocationDTO, Location>()
            .EqualityComparison((odto, o) => odto.Id == o.Id);

            CreateMap<PersonType, PersonTypeDTO>();
            CreateMap<PersonTypeDTO, PersonType>()
            .EqualityComparison((odto, o) => odto.Id == o.Id);

            CreateMap<Action, ActionDTO>();
            CreateMap<ActionDTO, Action>()
            .EqualityComparison((odto, o) => odto.Id == o.Id);

            CreateMap<Attachment, AttachmentDTO>();
            CreateMap<AttachmentDTO, Attachment>()
            .EqualityComparison((odto, o) => odto.Id == o.Id);

            CreateMap<EventType, EventTypeDTO>();
            CreateMap<EventTypeDTO, EventType>()
            .EqualityComparison((odto, o) => odto.Id == o.Id);

            CreateMap<IncidentEventType, IncidentEventTypeDTO>()
            .ReverseMap();

        }
    }

}
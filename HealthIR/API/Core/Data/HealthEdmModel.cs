
using System;
using Benton.HealthIR.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace HealthIR.Core.OData{
    public class HealthEdmModelBuilder {
        public IEdmModel GetEdmModel(IServiceProvider serviceProvider) {
            var odataBuilder = new ODataConventionModelBuilder(serviceProvider);
            odataBuilder.Namespace = "IncidentService";
            odataBuilder.EnableLowerCamelCase();
            
            BuildSets(odataBuilder);
            BuildFunctions(odataBuilder);
            BuildActions(odataBuilder);

            return odataBuilder.GetEdmModel();
        }
         
        private void BuildSets(ODataConventionModelBuilder builder ){
            //odataBuilder.EntitySet<IncidentReport>("Incidents");

            var incidentSet = builder.EntitySet<ReportDTO>("Incidents");
            incidentSet.EntityType
                .Filter() // Allow for the $filter Command
                .Count() // Allow for the $count Command
                .Expand() // Allow for the $expand Command
                .OrderBy() // Allow for the $orderby Command
                .Page() // Allow for the $top and $skip Commands
                .Select(); // Allow for the $select Command
            // This s to be able to pass up an empty or null id in post ops    
            incidentSet.EntityType.HasKey(_ => _.Id);   
            incidentSet.EntityType.Property(_ => _.Id).IsOptional();
            
        
            //odataBuilder.EntitySet<IncidentAction>("Actions");
            var actionSet = builder.EntitySet<ActionDTO>("Actions");
            actionSet.EntityType
                .Filter() // Allow for the $filter Command
                .Count() // Allow for the $count Command
                .Expand() // Allow for the $expand Command
                .OrderBy() // Allow for the $orderby Command
                .Page() // Allow for the $top and $skip Commands
                .Select(); // Allow for the $select Command

                        var locationSet = builder.EntitySet<LocationDTO>("Locations");
                        locationSet.EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select(); // Allow for the $select Command

                        var personTypeSet = builder.EntitySet<PersonTypeDTO>("PersonTypes");
                        personTypeSet.EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select(); // Allow for the $select Command

                        var incidentTypeSet = builder.EntitySet<IncidentTypeDTO>("IncidentTypes");
                        incidentTypeSet.EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select(); // Allow for the $select Command

                        var eventTypeSet = builder.EntitySet<IncidentEventTypeDTO>("IncidentEventTypes");
                        eventTypeSet.EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select(); // Allow for the $select Command
                        eventTypeSet.EntityType.HasKey(_ => _.ReportId );
                        eventTypeSet.EntityType.HasKey(_ => _.EventTypeId );
                        
/*
            var optionSet = builder.EntitySet<OptionCollectionDTO>("Options");
                        optionSet.EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .OrderBy() // Allow for the $orderby Command
                            .Select(); // Allow for the $select Command
  */          
        }

        private void BuildFunctions(ODataModelBuilder builder) {
            builder.EntityType<ReportDTO>()
                .Function("getActions")
                .ReturnsCollectionFromEntitySet<ActionDTO>("Actions");

            builder.EntityType<ReportDTO>()
                .Function("getAction")
                .ReturnsFromEntitySet<ActionDTO>("Actions")
                .Parameter<Guid>("actionId");

            builder.EntityType<ReportDTO>()
                .Function("postAction")
                .ReturnsFromEntitySet<ActionDTO>("Actions");

            builder.EntityType<ReportDTO>()
                .Function("patchAction")
                .ReturnsFromEntitySet<ActionDTO>("Actions")
                .Parameter<Guid>("actionId");

            builder.EntityType<ReportDTO>()
                  .Function("putAction")
                  .ReturnsFromEntitySet<ActionDTO>("Actions")
                  .Parameter<Guid>("actionId");
            
            builder.EntityType<ReportDTO>()
                  .Function("deleteAction")
                  .ReturnsFromEntitySet<ActionDTO>("Actions")
                  .Parameter<Guid>("actionId");

            builder.EntityType<ReportDTO>()
                  .Collection.Function("getAllAvailableOptions")
                  .Returns<string>();
        }

        private void BuildActions(ODataModelBuilder builder){}
    }
}
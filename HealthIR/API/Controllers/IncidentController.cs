using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Logging;

using AutoMapper;
using AutoMapper.AspNet.OData;

using HealthIR.Core.Data;
using Benton.HealthIR.Models;
namespace Benton.HealthIR.API.Controllers
{
    [ODataRoutePrefix("incidents")]
    public class IncidentsController: ODataController
    {
        private readonly IMapper _mapper;
        private readonly HealthDbContext Context;
        private readonly ILogger<IncidentsController> Logger;
        
        public IncidentsController( IMapper mapper, HealthDbContext ctx, ILogger<IncidentsController> logger ) {
            _mapper = mapper;
            Context = ctx;
            this.Logger = logger;
        }


        [ODataRoute]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetIncidents(ODataQueryOptions<ReportDTO> options, [FromQuery] bool restrict = true) {
            try {
                var query = Context.Incidents.Include(n => n.IncidentEventTypes).Where(i => i.Deleted == false);
            
                return Ok(await query.GetAsync(_mapper, options));
            }
            catch (Exception ex) {
                this.Logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }

}
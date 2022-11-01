using Microsoft.AspNetCore.Mvc;
using A.Services;
using Microsoft.AspNetCore.Cors;
using A.Services.Models;
using System.ComponentModel.DataAnnotations;

namespace A.Controllers
{
    [Route("api/v1/status")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> logger;
        private readonly IDivisionService divisionService;

        public StatusController(ILogger<StatusController> logger, IDivisionService divisionService)
        {
            this.logger = logger;
            this.divisionService = divisionService;
        }

        [HttpGet("{count}")]
        public IEnumerable<Status> GenerationStatuses([FromRoute]int count)
        {
            return divisionService.GenerationStatuses(count);
        }
    }
}

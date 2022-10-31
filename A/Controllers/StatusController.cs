using Microsoft.AspNetCore.Mvc;
using A.Services;
using A.Models;

namespace A.Controllers
{
    [Route("api/status")]
    [ApiController]
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

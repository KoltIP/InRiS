using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using A.Services;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Http.Features;
using System.Collections.Generic;

namespace A.Controllers
{
    [Route("api/division")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<DivisionController> logger;
        private readonly IDivisionService divisionService;
        
    }
}

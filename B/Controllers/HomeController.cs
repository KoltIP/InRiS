using AutoMapper;
using B.Models;
using B.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B.Controllers
{
    [Route("")]
    [ApiVersion("1.0")]
    public class HomeController : Controller
    {
        private readonly IMapper mapper;
        private readonly ILogger<HomeController> _logger;
        private readonly IDivisionService divisionService;

        public HomeController(IMapper mapper, ILogger<HomeController> logger, IDivisionService divisionService)
        {
            this.mapper = mapper;
            _logger = logger;
            this.divisionService = divisionService;           
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var models =  await divisionService.GetAllData();
            IEnumerable<DivisionResponse> response = models.Select(model => mapper.Map<DivisionResponse>(model));
            return View(response);
        }

        [HttpGet("Synchronization")]
        public async Task<IActionResult> Synchronization()
        {
            await divisionService.Synchronization();            
            var models = await divisionService.GetAllData();            
            IEnumerable<DivisionResponse> response = models.Select(model => mapper.Map<DivisionResponse>(model));
            return View("Index", response);
        }

        [HttpGet("Update")]
        public async Task<IEnumerable<DivisionResponse>> Update()
        {
            var models = await divisionService.GetAllData();
            IEnumerable<DivisionResponse> response = models.Select(model => mapper.Map<DivisionResponse>(model));
            return response;
        }


        [HttpGet("Find/{search}")]
        public async Task<IEnumerable<DivisionResponse>> Find([FromRoute] string search)
        {
            var models = await divisionService.FindData(search);
            IEnumerable<DivisionResponse> response = models.Select(model => mapper.Map<DivisionResponse>(model));
            return response;
        }


    }
}
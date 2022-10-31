using AutoMapper;
using B.Models;
using B.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace B.Controllers
{
    [Route("")]
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
            return View(models);
        }

        [HttpGet("Update")]
        public async Task<IEnumerable<DivisionModel>> Update()
        {
            var models = await divisionService.GetAllData();
            return models;
        }

        [HttpGet("Synchronization")]
        public async Task<IActionResult> Synchronization()
        {
            await divisionService.Synchronization();            
            var models = await divisionService.GetAllData();            
            return View("Index", models);
        }

        [HttpPost("Find/{search}")]
        public async Task<IEnumerable<DivisionModel>> Find([FromRoute]string search)
        {
            var models = await divisionService.FindData(search);
            return models;
        }
    }
}
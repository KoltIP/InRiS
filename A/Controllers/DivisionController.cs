using A.Services.Division.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using A.Services;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using A.Models;

namespace A.Controllers
{
    [Route("api/division")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogger<DivisionController> logger;
        private readonly IDivisionService divisionService;
        
        public DivisionController(IMapper mapper, ILogger<DivisionController> logger, IDivisionService divisionService)
        {            
            this.mapper = mapper;
            this.logger = logger;
            this.divisionService = divisionService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<DivisionModel> AddDivisionAsync(DivisionModel model)
        {
            return await divisionService.AddDivisions(model);
        }

        [HttpPost]
        [Route("Sync")]
        public  List<SerializeDivisionModelV2>/*async Task<DivisionModel>*/ SynchronizationAsync()
        {
            return Parser();               
        }

        private List<SerializeDivisionModelV2> Parser()
        {
            using (StreamReader r = new StreamReader("../A/Resources/TreeFile.json"))
            {
                string json = r.ReadToEnd();
                List<SerializeDivisionModelV2> items = JsonConvert.DeserializeObject<List<SerializeDivisionModelV2>>(json);
                return items;
            }

        }


        [HttpGet("getdata")]
        public async Task<IEnumerable<DivisionModel>> GetDataAsync()
        {
            return await divisionService.GetAllData();            
        }
    }
}

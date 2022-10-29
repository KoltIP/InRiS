using A.Services.Division.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using A.Services;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using A.Models;
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
        public  List<DivisionModel>/*async Task<DivisionModel>*/ SynchronizationAsync()
        {
            return Parser();               
        }

        private  List<DivisionModel> Parser()
        {
            List<SerializeDivisionModel> data;
            using (StreamReader sr = new StreamReader("../A/Resources/TreeFile.json"))
            {
                string json = sr.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<SerializeDivisionModel>>(json);
            }
            List<DivisionModel> result = new List<DivisionModel>();
            return result;
        }


        private List<DivisionModel> Converter(List<SerializeDivisionModel> source, List<DivisionModel> result)
        {    
            
            foreach (var item in source)
            {
                if (source == null)
                    return result;
                List<DivisionModel> modelss = source.Select(division => mapper.Map<DivisionModel>(division));
                result.Add(model);

            }
        }


        [HttpGet("getdata")]
        public async Task<IEnumerable<DivisionModel>> GetDataAsync()
        {
            return await divisionService.GetAllData();            
        }
    }
}

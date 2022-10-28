using A.Services.Division.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using A.Services;
using System.Reflection.Metadata;

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
        public DivisionModel SynchronizationAsync()
        {
            DivisionModel model = new DivisionModel()
            {
                Name = "First",
                Status = Data.Entities.Status.Active,
                ParentName = null,
                Parent = null,
                Children = new List<Data.Entities.Division>()
                {
                    new Data.Entities.Division() {
                        Name = "Second",
                        Status = Data.Entities.Status.Active,
                        ParentName = null,
                        Parent = null,
                    }
                };
            };
            using (FileStream fs = new FileStream("Resources/TreeFile.json", FileMode.Open))
            {
                model = JsonSerializer.Deserialize<DivisionModel>(fs);                
            }
            return model;
        }

        [HttpGet("getdata")]
        public async Task<IEnumerable<DivisionModel>> GetDataAsync()
        {
            return await divisionService.GetAllData();            
        }
    }
}

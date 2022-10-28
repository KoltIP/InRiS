﻿using A.Services.Division;
using A.Services.Division.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<DivisionModel> AddDivisionAsync(DivisionModel model)
        {
            return await divisionService.AddDivisions(model);
        }

        [HttpGet("getdata")]
        public async Task<IEnumerable<DivisionModel>> GetDataAsync()
        {
            return await divisionService.GetAllData();

            //var divisions = await divisionService.GetDivisions();
            //var response = mapper.Map<IEnumerable<DivisionModel>>(divisions);
            //return response;

            //return new List<DivisionModel>()
            //{
            //    new DivisionModel()
            //    {
            //        Name = "1",
            //        Status = A.Data.Entities.Status.Active,
            //        UpperName =null,
            //    },
            //    new DivisionModel()
            //    {
            //        Name = "2",
            //        Status = A.Data.Entities.Status.Active,
            //        UpperName ="1",
            //    },
            //    new DivisionModel()
            //    {
            //        Name = "3",
            //        Status =A.Data.Entities.Status.Active,
            //        UpperName ="1",
            //    },
            //    new DivisionModel()
            //    {
            //        Name = "4",
            //        Status = A.Data.Entities.Status.Active,
            //        UpperName ="3",
            //    },
            //};
        }
    }
}

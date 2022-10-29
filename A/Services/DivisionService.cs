using A.Data.Context;
using A.Services.Division.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;

namespace A.Services
{
    public class DivisionService : IDivisionService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DivisionService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DivisionModel>> GetAllData()
        {
            var divisions = _dbContext.Divisions.AsQueryable();

            var divisionList = await divisions.ToListAsync();
            IEnumerable<DivisionModel> divisionModelList = divisionList.Select(division => _mapper.Map<DivisionModel>(division));

            return divisionModelList;
        }



        public async Task<DivisionModel> AddDivisions(DivisionModel model)
        {
            var division = _mapper.Map<Data.Entities.Division>(model);

            await _dbContext.Divisions.AddAsync(division);
            _dbContext.SaveChanges();

            return _mapper.Map<DivisionModel>(division);
        }

        public async Task Synchronization(IEnumerable<DivisionModel> listOfModels)
        {
            foreach (var item in listOfModels)
            {
                var division = _mapper.Map<Data.Entities.Division>(item);
                division = await _dbContext.Divisions.FirstOrDefaultAsync(x => x.Name == division.Name);
                if (division != null)
                    _dbContext.Divisions.Update(division);
                else
                    await _dbContext.Divisions.AddAsync(division);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

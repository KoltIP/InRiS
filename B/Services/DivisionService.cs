using AutoMapper;
using B.Data.Context;
using B.Data.Entities;
using B.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace B.Services
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

        public async Task Synchronization()
        {
            IEnumerable<DivisionModel> listOfModels = FileParse();
            foreach (var item in listOfModels)
            {
                var division = _mapper.Map<Data.Entities.Division>(item);
                var findDivision = await _dbContext.Divisions.FirstOrDefaultAsync(x => x.Name == division.Name);
                if (findDivision == null)
                {
                    await _dbContext.Divisions.AddAsync(division);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    findDivision = division;
                    await _dbContext.SaveChangesAsync();
                }                  
            }
        }

        private List<DivisionModel> FileParse()
        {
            List<SerializeDivisionModel> data;
            using (StreamReader sr = new StreamReader(Settings.FilePath))
            {
                string json = sr.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<SerializeDivisionModel>>(json);
            }
            List<DivisionModel> result = new List<DivisionModel>();
            return ConvertMembers(data, result);
        }

        private List<DivisionModel> ConvertMembers(List<SerializeDivisionModel> source, List<DivisionModel> destination)
        {
            if (source == null)
                return destination;
            for (int i = 0; i < source.Count; i++)
            {
                destination.Add(_mapper.Map<DivisionModel>(source[i]));
                ConvertMembers(source[i].Divisions, destination);
            }
            return destination;
        }

    }
}

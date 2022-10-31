using AutoMapper;
using B.Data.Context;
using B.Data.Entities;
using B.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace B.Services
{
    public class DivisionService : IDivisionService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public DivisionService(ApplicationDbContext dbContext, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<DivisionModel>> GetAllData()
        {
            var divisions = _dbContext.Divisions.AsQueryable();
            var divisionList = await divisions.ToListAsync();            
            List<DivisionModel> divisionModelList = divisionList.Select(division => _mapper.Map<DivisionModel>(division)).ToList();
            if (!divisionModelList.Any())
                return divisionModelList;
            List<Status> statuses = (await GetStatuses(divisionModelList.Count())).ToList();
            for (int i = 0; i < divisionModelList.Count(); i++)            
                divisionModelList[i].Status = statuses[i];            
            return divisionModelList;
        }

        private async Task<IEnumerable<Status>> GetStatuses(int count)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string url = $"{Settings.ApiRoot}/status/{count}";
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                throw new Exception(content);            
            var statuses = JsonSerializer.Deserialize<IEnumerable<Status>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Status>();
            return statuses;
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

        public async Task<IEnumerable<DivisionModel>> FindData(string findString)
        {
            var divisions = _dbContext.Divisions.AsQueryable();
            var divisionList = (await divisions.ToListAsync()).Where<Division>(x=>x.Name.Equals(findString));
            List<DivisionModel> divisionModelList = divisionList.Select(division => _mapper.Map<DivisionModel>(division)).ToList();
            if (!divisionModelList.Any())
                return divisionModelList;
            List<Status> statuses = (await GetStatuses(divisionModelList.Count())).ToList();
            for (int i = 0; i < divisionModelList.Count(); i++)
                divisionModelList[i].Status = statuses[i];
            return divisionModelList;
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

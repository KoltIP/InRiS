using A.Services.Division.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;

namespace A.Services
{
    public interface IDivisionService
    {
        Task<IEnumerable<DivisionModel>> GetAllData();
        Task<DivisionModel> AddDivisions(DivisionModel model);
        Task Synchronization(IEnumerable<DivisionModel> listOfModels);
    }
}

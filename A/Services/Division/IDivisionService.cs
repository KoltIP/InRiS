using A.Services.Division.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;

namespace A.Services.Division
{
    public interface IDivisionService
    {
        Task<IEnumerable<DivisionModel>> GetAllData();
        Task<DivisionModel> AddDivisions(DivisionModel model);
    }
}

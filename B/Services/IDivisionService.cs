using B.Models;

namespace B.Services
{
    public interface IDivisionService
    {
        Task<IEnumerable<DivisionModel>> GetAllData();
        Task<IEnumerable<DivisionModel>> FindData(string findString);
        Task Synchronization();
    }
}

using A.Models;

namespace A.Services
{
    public interface IDivisionService
    {
        IEnumerable<Status> GenerationStatuses(int count);
    }
}

using A.Models;

namespace A.Services
{
    public class DivisionService : IDivisionService
    {
        public IEnumerable<Status> GenerationStatuses(int count)
        {
            List<Status> statuses = new List<Status>();
            Random random = new Random();
            for (int i = 0; i < count; i++)                       
                statuses.Add((Status)random.Next(0, 2));            
            return statuses;
        }
    }
}

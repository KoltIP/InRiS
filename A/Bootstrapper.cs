using A.Services.Division;
using A.Services.Division.Models;

namespace A
{
    public static class Bootstrapper
    {
        public static void AddAppServices(this IServiceCollection services)
        {            
            services.AddDivisionService();
        }
    }
}

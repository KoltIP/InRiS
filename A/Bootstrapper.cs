using A.Services.Division;

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

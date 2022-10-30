using B.Services;

namespace B
{
    public static class Bootstrapper
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddDivisionService();
        }
    }
}

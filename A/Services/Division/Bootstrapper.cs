namespace A.Services.Division
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDivisionService(this IServiceCollection services)
        {
            services.AddSingleton<IDivisionService, DivisionService>();

            return services;
        }
    }
}

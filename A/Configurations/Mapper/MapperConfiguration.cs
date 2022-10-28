using A.Services.Division.Models;

namespace A.Configurations.Mapper
{
    public static class MapperConfiguration
    {
        public static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DivisionModelProfile), typeof(DivisionProfile));
            return services;
        }
    }
}

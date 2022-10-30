using B.Models;

namespace B.Configuration.Mapper
{
    public static class MapperConfiguration
    {
        public static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DivisionModelProfile), typeof(DivisionProfile), typeof(ParseDivisionProfile));
            return services;
        }
    }
}

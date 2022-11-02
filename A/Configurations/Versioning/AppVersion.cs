using Microsoft.AspNetCore.Mvc;

namespace A.Configurations.Versioning
{
    public static class AppVersion
    {
        public static IServiceCollection AddAppVersion(this IServiceCollection services)
        { 
            return services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });            
        }
    }
}

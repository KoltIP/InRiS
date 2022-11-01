namespace A.Configurations.Cors
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddAppCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: Settings.CorsName,
                                  policy =>
                                  {
                                      policy
                                            .WithOrigins(Settings.AllowedHosts)
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
                                  });
            });
            return services;
        }

        public static void UseAppCors(this IApplicationBuilder app)
        {
            app.UseCors(Settings.CorsName);
        }
    }
}

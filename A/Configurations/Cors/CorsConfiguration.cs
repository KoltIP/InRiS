namespace A.Configurations.Cors
{
    public static class CorsConfiguration
    {
        private static string CorsName = "myAllowSpecificOrigins";
        private static string AllowedHosts = "http://localhost:5031";


        public static IServiceCollection AddAppCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsName,
                                  policy =>
                                  {
                                      policy.WithOrigins(AllowedHosts);
                                  });
            });
            return services;
        }

        public static void UseAppCors(this IApplicationBuilder app)
        {
            app.UseCors(CorsName);
        }
    }
}

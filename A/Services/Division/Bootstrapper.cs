﻿namespace A.Services.Division
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDivisionService(this IServiceCollection services)
        {
            services.AddTransient<IDivisionService, DivisionService>();

            return services;
        }
    }
}

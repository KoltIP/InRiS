using B.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace B.Configuration.Db
{
    public static class DbConfiguration
    {
        public static IServiceCollection AddAppDbOption(this WebApplicationBuilder builder)
        {            
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            return builder.Services;
        }
    }
}

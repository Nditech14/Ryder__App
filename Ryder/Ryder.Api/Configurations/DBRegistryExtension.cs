using Microsoft.EntityFrameworkCore;
using Ryder.Domain.Context;

namespace Ryder.Api.Configurations
{
    public static class DBRegistryExtension
    {
        public static void AddDbContextAndConfigurations(this IServiceCollection services, IWebHostEnvironment env,
            IConfiguration config)
        {
            services.AddDbContextPool<ApplicationContext>(options =>
            {
                string connStr;

                if (env.IsDevelopment())
                {
                    connStr = config.GetConnectionString("DefaultConnection");
                   options.UseNpgsql(connStr);
                    
                }
                else
                {
                    connStr = config.GetConnectionString("DefaultConnection");
                   options.UseNpgsql(connStr);
                   
                }
            });
        }
    }
}
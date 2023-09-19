using Microsoft.EntityFrameworkCore;
using Ryder.Domain.Context;

namespace Ryder.Api.Configurations
{
    public static class DBRegistryExtension
    {
        private static string GetRenderConnectionString()
        {
            // Get the Database URL from the ENV variables in Render
            string connectionUrl =
                $"postgres://ryder_db_user:Vf7cAgBOoL5WckHozGE4lNL1sEN0VDpN@dpg-ck4c6ms2kpls73dlbmk0-a.oregon-postgres.render.com/ryder_db";

            // parse the connection string
            var databaseUri = new Uri(connectionUrl);
            string db = databaseUri.LocalPath.TrimStart('/');
            string[] userInfo = databaseUri.UserInfo.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            var x = $"User ID={userInfo[0]};Password={userInfo[1]};Host={databaseUri.Host};Port=5432;" +
                    $"Database={db};Pooling=true;SSL Mode=Require;Trust Server Certificate=True;";
            return x;
        }

        public static void AddDbContextAndConfigurations(this IServiceCollection services, IWebHostEnvironment env,
            IConfiguration config)
        {
            services.AddDbContextPool<ApplicationContext>(options =>
            {
                string connStr;

                if (env.IsDevelopment())
                {
                    connStr = GetRenderConnectionString();
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